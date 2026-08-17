using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VocabGrid.DTOs;
using VocabGrid.Entities;
using VocabGrid.Interfaces;
using VocabGrid.Services;

namespace VocabGrid.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgressController : ControllerBase
{
    /// <summary>Dereceli oturumda bir seferde gösterilecek en fazla kart.</summary>
    private const int MaxSessionLimit = 100;

    /// <summary>
    /// "all" modunun tavanı. Oturum tavanından yüksek çünkü orası bir çalışma
    /// oturumu değil, kullanıcının kategorilerindeki kelimelerin listesi.
    /// </summary>
    private const int MaxBrowseLimit = 500;

    private readonly IUnitOfWork _unitOfWork;

    public ProgressController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("lessons")]
    public async Task<IActionResult> GetLessonProgress()
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var lessons = await _unitOfWork.Repository<Lesson>().GetAllAsync();
        var progressByLesson = (await _unitOfWork.Repository<UserProgress>()
                .FindAsync(progress => progress.UserID == userId.Value))
            .ToDictionary(progress => progress.LessonID);

        return Ok(lessons.OrderBy(lesson => lesson.OrderIndex).Select(lesson =>
        {
            progressByLesson.TryGetValue(lesson.LessonID, out var progress);
            return new
            {
                LessonId = lesson.LessonID,
                lesson.Title,
                lesson.Level,
                lesson.OrderIndex,
                Score = progress?.Score ?? 0,
                Completed = progress?.Completed ?? false,
                LastAccess = progress?.LastAccess
            };
        }));
    }

    [HttpPut("lessons/{lessonId:int}")]
    public async Task<IActionResult> UpdateLessonProgress(int lessonId, [FromBody] UpdateLessonProgressDto dto)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var lesson = await _unitOfWork.Repository<Lesson>().GetByIdAsync(lessonId);
        if (lesson is null)
        {
            return NotFound("Lesson not found.");
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var progressRepository = _unitOfWork.Repository<UserProgress>();
        var progress = (await progressRepository.FindAsync(candidate =>
                candidate.UserID == user.Id && candidate.LessonID == lessonId))
            .FirstOrDefault();
        var occurredAt = DateTime.UtcNow;

        if (progress is null)
        {
            progress = new UserProgress
            {
                UserID = user.Id,
                LessonID = lessonId,
                Score = dto.Score,
                Completed = dto.Completed,
                LastAccess = occurredAt
            };
            await progressRepository.AddAsync(progress);
        }
        else
        {
            progress.Score = Math.Max(progress.Score, dto.Score);
            progress.Completed |= dto.Completed;
            progress.LastAccess = occurredAt;
            progressRepository.Update(progress);
        }

        var activity = new StudyActivity
        {
            UserId = user.Id,
            LessonId = lessonId,
            OccurredAt = occurredAt,
            ActivityType = "Lesson",
            Result = dto.Completed ? "Completed" : null,
            DurationSeconds = dto.StudyDurationSeconds,
            XpEarned = dto.Completed ? 5 : 0
        };
        await _unitOfWork.Repository<StudyActivity>().AddAsync(activity);
        await DailySummaryEngine.RecordAsync(_unitOfWork, activity);

        StudyEngine.ApplyXp(user, activity.XpEarned);
        await StudyEngine.UpdateStreakAsync(_unitOfWork, user, occurredAt);
        var newlyUnlocked = await AchievementEvaluator.UnlockEligibleAsync(_unitOfWork, user, activity);
        await _unitOfWork.CompleteAsync();

        return Ok(new
        {
            LessonId = lesson.LessonID,
            lesson.Title,
            progress.Score,
            progress.Completed,
            progress.LastAccess,
            NewlyUnlockedAchievements = newlyUnlocked.Select(badge => new { badge.Id, badge.Name, badge.Description, badge.Icon })
        });
    }

    /// <summary>
    /// Kullanıcının seçtiği kategorilerden bir çalışma oturumu.
    ///
    /// <c>mode</c>:
    ///   <c>new</c>    — yalnızca hiç görülmemiş kelimeler
    ///   <c>review</c> — yalnızca zamanı gelmiş tekrarlar
    ///   <c>mixed</c>  — önce tekrarlar, kalan yer yeni kelimelerle dolar
    ///   <c>all</c>    — tekrar durumuna bakmadan hepsi (salt okunur listeleme)
    ///
    /// Yalnızca müfredat kelimelerini (<c>DeckId == null</c>) döndürür:
    /// kategori seçimi paylaşılan içerik içindir, kullanıcının kendi destesi
    /// zaten <see cref="GetDueReviews"/> ile çalışılıyor.
    /// </summary>
    [HttpGet("session")]
    [ProducesResponseType(typeof(IEnumerable<SessionCardDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategorySession(
        [FromQuery] string mode = "mixed",
        [FromQuery] int limit = 50)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (mode is not ("new" or "review" or "mixed" or "all"))
        {
            return BadRequest("mode must be new, review, mixed, or all.");
        }

        // "all" bir oturum değil, listeleme: oturum tavanı uygulanırsa
        // kullanıcının kelimelerinin yalnızca ilk 50'si görünür.
        var maximum = mode == "all" ? MaxBrowseLimit : MaxSessionLimit;
        if (limit < 1 || limit > maximum)
        {
            return BadRequest($"limit must be between 1 and {maximum} for mode '{mode}'.");
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var categoryIds = await SelectedCategoryIdsAsync(userId.Value);
        if (categoryIds.Count == 0)
        {
            return Ok(Array.Empty<SessionCardDto>());
        }

        var target = user.TargetLanguageCode;
        var native = user.NativeLanguageCode;

        // Kart iki çeviriden oluşur: ön yüz hedef dilde, arka yüz ana dilde.
        // Bir kavram ancak ikisi de varsa çalışılabilir — bir dile içerik
        // kısmen girildiğinde eksik kavramlar sessizce atlanır, yarım kart
        // gösterilmez.
        var translations = _unitOfWork.Repository<ConceptTranslation>().Query();

        var pool = _unitOfWork.Repository<Concept>().Query()
            .Where(concept => concept.CategoryId != null
                && categoryIds.Contains(concept.CategoryId.Value)
                && translations.Any(t => t.ConceptId == concept.Id && t.LanguageCode == target)
                && translations.Any(t => t.ConceptId == concept.Id && t.LanguageCode == native));

        // İlerleme hedef dile göre: aynı kavramı Almanca ve İspanyolca
        // öğrenmek iki ayrı iş.
        var progress = _unitOfWork.Repository<UserWordProgress>().Query()
            .Where(row => row.UserID == userId.Value
                && row.ConceptId != null
                && row.LanguageCode == target);

        if (mode == "all")
        {
            return Ok(await pool
                .OrderBy(concept => concept.OrderIndex)
                .Take(limit)
                .Select(concept => new SessionCardDto
                {
                    ConceptId = concept.Id,
                    CategoryId = concept.CategoryId,
                    Term = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).Term,
                    Translation = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == native).Term,
                    ExampleSentence = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).ExampleSentence,
                    AudioUrl = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).AudioUrl,
                    MasteryLevel = 0,
                    IsNew = false
                })
                .ToListAsync());
        }

        var now = DateTime.UtcNow;
        var cards = new List<SessionCardDto>();

        if (mode is "review" or "mixed")
        {
            cards.AddRange(await progress
                .Where(row => row.NextReviewDate != null
                    && row.NextReviewDate <= now
                    && pool.Any(concept => concept.Id == row.ConceptId))
                .OrderBy(row => row.NextReviewDate)
                .Take(limit)
                .Select(row => new SessionCardDto
                {
                    ConceptId = row.ConceptId!.Value,
                    CategoryId = row.Concept!.CategoryId,
                    Term = translations.First(t => t.ConceptId == row.ConceptId && t.LanguageCode == target).Term,
                    Translation = translations.First(t => t.ConceptId == row.ConceptId && t.LanguageCode == native).Term,
                    ExampleSentence = translations.First(t => t.ConceptId == row.ConceptId && t.LanguageCode == target).ExampleSentence,
                    AudioUrl = translations.First(t => t.ConceptId == row.ConceptId && t.LanguageCode == target).AudioUrl,
                    MasteryLevel = row.MasteryLevel,
                    IsNew = false
                })
                .ToListAsync());
        }

        if (mode is "new" or "mixed" && cards.Count < limit)
        {
            cards.AddRange(await pool
                .Where(concept => !progress.Any(row => row.ConceptId == concept.Id))
                .OrderBy(concept => concept.OrderIndex)
                .Take(limit - cards.Count)
                .Select(concept => new SessionCardDto
                {
                    ConceptId = concept.Id,
                    CategoryId = concept.CategoryId,
                    Term = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).Term,
                    Translation = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == native).Term,
                    ExampleSentence = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).ExampleSentence,
                    AudioUrl = translations.First(t => t.ConceptId == concept.Id && t.LanguageCode == target).AudioUrl,
                    MasteryLevel = 0,
                    IsNew = true
                })
                .ToListAsync());
        }

        return Ok(cards);
    }

    /// <summary>
    /// Seçili kategorilerde kaç yeni ve kaç zamanı gelmiş kavram olduğu.
    /// Mod düğmeleri boş bir oturum açmadan önce bunu okuyor.
    /// </summary>
    [HttpGet("session/counts")]
    [ProducesResponseType(typeof(SessionCountsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSessionCounts()
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var categoryIds = await SelectedCategoryIdsAsync(userId.Value);
        if (categoryIds.Count == 0)
        {
            return Ok(new SessionCountsDto());
        }

        var target = user.TargetLanguageCode;
        var native = user.NativeLanguageCode;

        var translations = _unitOfWork.Repository<ConceptTranslation>().Query();

        var pool = _unitOfWork.Repository<Concept>().Query()
            .Where(concept => concept.CategoryId != null
                && categoryIds.Contains(concept.CategoryId.Value)
                && translations.Any(t => t.ConceptId == concept.Id && t.LanguageCode == target)
                && translations.Any(t => t.ConceptId == concept.Id && t.LanguageCode == native));

        var progress = _unitOfWork.Repository<UserWordProgress>().Query()
            .Where(row => row.UserID == userId.Value
                && row.ConceptId != null
                && row.LanguageCode == target);

        var now = DateTime.UtcNow;

        return Ok(new SessionCountsDto
        {
            SelectedCategories = categoryIds.Count,
            NewAvailable = await pool.CountAsync(concept => !progress.Any(row => row.ConceptId == concept.Id)),
            DueCount = await progress.CountAsync(row => row.NextReviewDate != null
                && row.NextReviewDate <= now
                && pool.Any(concept => concept.Id == row.ConceptId))
        });
    }

    private async Task<List<int>> SelectedCategoryIdsAsync(int userId) =>
        await _unitOfWork.Repository<UserCategory>().Query()
            .Where(link => link.UserId == userId)
            .Select(link => link.CategoryId)
            .ToListAsync();

    [HttpGet("reviews/due")]
    public async Task<IActionResult> GetDueReviews([FromQuery] int? deckId, [FromQuery] int take = 50)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (take is < 1 or > 100)
        {
            return BadRequest("take must be between 1 and 100.");
        }

        if (deckId is not null && !await IsDeckOwnedByUserAsync(deckId.Value, userId.Value))
        {
            return NotFound("Deck not found.");
        }

        // Tek sorgu, tek geçiş. Buradaki eski uygulama üç ayrı listeyi
        // belleğe çekiyordu — kullanıcının tüm desteleri, tüm müfredat
        // bağlantıları ve kullanıcının *bütün* UserWordProgress satırları —
        // sonra süzme, sıralama ve Take'i C# tarafında yapıyordu. Yani
        // şemadaki indeksler hiç kullanılmıyor, take=50 istense bile
        // ilerleme tablosunun tamamı ağdan geçiyordu.
        //
        // Deste-siz bir kart yalnızca paylaşılan müfredata aitse
        // çalışılabilir; sahipsiz deste-siz kayıtlar tekrar kuyruğuna
        // girmez. Bu kural aşağıdaki LessonVocabularies alt sorgusunda.
        var includeCurriculum = deckId is null;
        var now = DateTime.UtcNow;

        var lessonLinks = _unitOfWork.Repository<LessonVocabulary>().Query();
        var progress = _unitOfWork.Repository<UserWordProgress>().Query()
            .Where(row => row.UserID == userId.Value);

        var pool = _unitOfWork.Repository<Vocabulary>().Query()
            .Where(word => deckId != null
                ? word.DeckId == deckId
                : (word.DeckId != null && word.Deck!.UserId == userId.Value)
                  || (includeCurriculum && word.DeckId == null
                      && lessonLinks.Any(link => link.WordID == word.WordID)));

        // Sol birleştirme: ilerleme kaydı olmayan kelime hiç çalışılmamış
        // demektir ve zamanı gelmiş sayılır.
        var due = await pool
            .Select(word => new
            {
                Word = word,
                Progress = progress.FirstOrDefault(row => row.WordID == word.WordID)
            })
            .Where(x => x.Progress == null
                || x.Progress.NextReviewDate == null
                || x.Progress.NextReviewDate <= now)
            .OrderBy(x => x.Progress == null ? 0 : 1)
            .ThenBy(x => x.Progress!.NextReviewDate)
            .Take(take)
            .Select(x => new
            {
                WordId = x.Word.WordID,
                x.Word.DeckId,
                x.Word.CategoryId,
                x.Word.Term,
                x.Word.Translation,
                x.Word.ExampleSentence,
                x.Word.ImageUrl,
                x.Word.AudioUrl,
                MasteryLevel = x.Progress == null ? 0 : x.Progress.MasteryLevel,
                ReviewCount = x.Progress == null ? 0 : x.Progress.ReviewCount,
                IntervalDays = x.Progress == null ? 0 : x.Progress.IntervalDays,
                EaseFactor = x.Progress == null ? 2.5 : x.Progress.EaseFactor,
                LastRating = x.Progress == null ? null : x.Progress.LastRating,
                NextReviewDate = x.Progress == null ? null : x.Progress.NextReviewDate
            })
            .ToListAsync();

        return Ok(due);
    }

    /// <summary>
    /// Kategori oturumundaki bir kavramın değerlendirilmesi.
    ///
    /// <c>reviews/{wordId}</c>'dan ayrı, çünkü ilerleme burada kavrama
    /// <em>ve hedef dile</em> bağlı: aynı kavramı Almanca ve İspanyolca
    /// öğrenmek iki ayrı iştir. Aralık, kolaylık katsayısı ve ustalık hesabı
    /// ikisinde de aynı <see cref="StudyEngine"/> kodundan geçer.
    /// </summary>
    [HttpPost("concepts/{conceptId:int}/reviews")]
    public async Task<IActionResult> SubmitConceptReview(int conceptId, [FromBody] SubmitReviewDto dto)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var target = user.TargetLanguageCode;

        // Hedef dilde çevirisi olmayan bir kavram bu kullanıcıya hiç
        // gösterilmedi; değerlendirmesi de kabul edilmemeli.
        var studiable = await _unitOfWork.Repository<ConceptTranslation>().Query()
            .AnyAsync(t => t.ConceptId == conceptId && t.LanguageCode == target);
        if (!studiable)
        {
            return NotFound("Concept is not available for review in your target language.");
        }

        var progressRepository = _unitOfWork.Repository<UserWordProgress>();
        var progress = await progressRepository.Query()
            .FirstOrDefaultAsync(row => row.UserID == user.Id
                && row.ConceptId == conceptId
                && row.LanguageCode == target);

        var reviewedAt = DateTime.UtcNow;
        var isNew = progress is null;
        progress ??= new UserWordProgress
        {
            UserID = user.Id,
            ConceptId = conceptId,
            LanguageCode = target,
            LastReviewedAt = reviewedAt
        };

        var schedule = StudyEngine.CalculateReviewSchedule(
            progress.IntervalDays, progress.EaseFactor, dto.Rating, reviewedAt);

        progress.IntervalDays = schedule.IntervalDays;
        progress.EaseFactor = schedule.EaseFactor;
        progress.NextReviewDate = schedule.NextReviewDate;
        progress.LastReviewedAt = reviewedAt;
        progress.LastRating = dto.Rating;
        progress.ReviewCount++;
        progress.MasteryLevel = Math.Clamp(progress.MasteryLevel + schedule.MasteryDelta, 0, 5);

        if (isNew)
        {
            await progressRepository.AddAsync(progress);
        }
        else
        {
            progressRepository.Update(progress);
        }

        var xpEarned = dto.Rating switch
        {
            "Easy" => 2,
            "Medium" => 1,
            "Hard" => 1,
            _ => 0
        };

        // WordId doldurulmuyor: StudyActivity kartlara bağlı, kavramlara
        // değil. Seri ve günlük özet yalnızca "bugün çalışıldı mı" bilgisine
        // baktığı için bu kayıt onlar açısından yeterli.
        var activity = new StudyActivity
        {
            UserId = user.Id,
            OccurredAt = reviewedAt,
            ActivityType = "Review",
            Result = dto.Rating,
            DurationSeconds = dto.DurationSeconds,
            XpEarned = xpEarned
        };
        await _unitOfWork.Repository<StudyActivity>().AddAsync(activity);
        await DailySummaryEngine.RecordAsync(_unitOfWork, activity);

        StudyEngine.ApplyXp(user, xpEarned);
        await StudyEngine.UpdateStreakAsync(_unitOfWork, user, reviewedAt);
        await _unitOfWork.CompleteAsync();

        return Ok(new
        {
            ConceptId = conceptId,
            LanguageCode = target,
            progress.MasteryLevel,
            progress.ReviewCount,
            progress.IntervalDays,
            progress.EaseFactor,
            progress.LastRating,
            progress.NextReviewDate
        });
    }

    [HttpPost("reviews/{wordId:int}")]
    public async Task<IActionResult> SubmitReview(int wordId, [FromBody] SubmitReviewDto dto)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var word = await _unitOfWork.Repository<Vocabulary>().GetByIdAsync(wordId);
        if (word is null)
        {
            return NotFound("Flashcard not found.");
        }

        if (!await IsReviewableByUserAsync(word, userId.Value))
        {
            return NotFound("Flashcard is not available for review.");
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var progressRepository = _unitOfWork.Repository<UserWordProgress>();
        var progress = (await progressRepository.FindAsync(candidate =>
                candidate.UserID == user.Id && candidate.WordID == word.WordID))
            .FirstOrDefault();
        var reviewedAt = DateTime.UtcNow;

        var isNewProgress = progress is null;
        if (isNewProgress)
        {
            progress = new UserWordProgress
            {
                UserID = user.Id,
                WordID = word.WordID,
                LastReviewedAt = reviewedAt
            };
        }

        var userWordProgress = progress!;

        var schedule = StudyEngine.CalculateReviewSchedule(
            userWordProgress.IntervalDays,
            userWordProgress.EaseFactor,
            dto.Rating,
            reviewedAt);

        userWordProgress.IntervalDays = schedule.IntervalDays;
        userWordProgress.EaseFactor = schedule.EaseFactor;
        userWordProgress.NextReviewDate = schedule.NextReviewDate;
        userWordProgress.LastReviewedAt = reviewedAt;
        userWordProgress.LastRating = dto.Rating;
        userWordProgress.ReviewCount++;
        userWordProgress.MasteryLevel = Math.Clamp(userWordProgress.MasteryLevel + schedule.MasteryDelta, 0, 5);
        if (isNewProgress)
        {
            await progressRepository.AddAsync(userWordProgress);
        }
        else
        {
            progressRepository.Update(userWordProgress);
        }

        var xpEarned = dto.Rating switch
        {
            "Easy" => 2,
            "Medium" => 1,
            "Hard" => 1,
            _ => 0
        };
        var activity = new StudyActivity
        {
            UserId = user.Id,
            WordId = word.WordID,
            DeckId = word.DeckId,
            OccurredAt = reviewedAt,
            ActivityType = "Review",
            Result = dto.Rating,
            DurationSeconds = dto.DurationSeconds,
            XpEarned = xpEarned
        };
        await _unitOfWork.Repository<StudyActivity>().AddAsync(activity);
        await DailySummaryEngine.RecordAsync(_unitOfWork, activity);

        StudyEngine.ApplyXp(user, xpEarned);
        await StudyEngine.UpdateStreakAsync(_unitOfWork, user, reviewedAt);
        var newlyUnlocked = await AchievementEvaluator.UnlockEligibleAsync(_unitOfWork, user, activity);
        await _unitOfWork.CompleteAsync();

        return Ok(new
        {
            WordId = word.WordID,
            dto.Rating,
            userWordProgress.MasteryLevel,
            userWordProgress.ReviewCount,
            userWordProgress.IntervalDays,
            userWordProgress.EaseFactor,
            userWordProgress.NextReviewDate,
            NewlyUnlockedAchievements = newlyUnlocked.Select(badge => new { badge.Id, badge.Name, badge.Description, badge.Icon })
        });
    }

    [HttpGet("streak")]
    public async Task<IActionResult> GetStreak()
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var activityDates = (await _unitOfWork.Repository<StudyActivity>()
                .FindAsync(activity => activity.UserId == user.Id))
            .Select(activity => activity.OccurredAt);

        return Ok(new
        {
            CurrentStreak = StudyEngine.CalculateCurrentStreak(activityDates, DateTime.UtcNow),
            LongestStreak = Math.Max(user.LongestStreak, StudyEngine.CalculateLongestStreak(activityDates)),
            user.DailyGoalMinutes
        });
    }

    /// <summary>
    /// İstatistik ekranının ısı haritası için gün gün özet.
    ///
    /// Ham aktiviteleri tarayıp gruplamak yerine <see cref="DailyStudySummary"/>
    /// satırlarını okur — aynı sayılar, ama bir yıllık aralıkta on binlerce
    /// satır yerine en fazla 365 satır.
    ///
    /// Çalışılmayan günler için satır yoktur ve uydurulmaz; boşluğu istemci
    /// "o gün aktivite yok" olarak çizer.
    /// </summary>
    [HttpGet("daily-summary")]
    public async Task<IActionResult> GetDailySummary(
        [FromQuery] DateOnly? from = null,
        [FromQuery] DateOnly? to = null)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        // Varsayılan bir yıl: ısı haritasının gösterdiği aralık.
        var start = from ?? today.AddYears(-1);
        var end = to ?? today;

        if (start > end)
        {
            return BadRequest(new { Message = "'from' tarihi 'to' tarihinden sonra olamaz." });
        }

        var summaries = await _unitOfWork.Repository<DailyStudySummary>()
            .FindAsync(summary =>
                summary.UserId == userId.Value &&
                summary.Day >= start &&
                summary.Day <= end);

        var days = summaries.OrderBy(summary => summary.Day).ToList();

        return Ok(new
        {
            From = start,
            To = end,
            TotalReviews = days.Sum(day => day.ReviewCount),
            TotalCorrect = days.Sum(day => day.CorrectCount),
            TotalQuizzes = days.Sum(day => day.QuizCount),
            TotalLessons = days.Sum(day => day.LessonCount),
            TotalStudySeconds = days.Sum(day => day.StudySeconds),
            TotalXp = days.Sum(day => day.XpEarned),
            ActiveDays = days.Count,
            Days = days.Select(day => new
            {
                day.Day,
                day.ReviewCount,
                day.CorrectCount,
                day.QuizCount,
                day.LessonCount,
                day.StudySeconds,
                day.XpEarned
            })
        });
    }

    private async Task<bool> IsDeckOwnedByUserAsync(int deckId, int userId)
    {
        var deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(deckId);
        return deck?.UserId == userId;
    }

    private async Task<bool> IsReviewableByUserAsync(Vocabulary word, int userId)
    {
        if (word.DeckId is not null)
        {
            return await IsDeckOwnedByUserAsync(word.DeckId.Value, userId);
        }

        return (await _unitOfWork.Repository<LessonVocabulary>()
                .FindAsync(link => link.WordID == word.WordID))
            .Any();
    }

    private int? TryGetUserId()
    {
        var raw = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(raw, out var id) ? id : null;
    }
}
