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

        var categoryIds = await SelectedCategoryIdsAsync(userId.Value);
        if (categoryIds.Count == 0)
        {
            return Ok(Array.Empty<SessionCardDto>());
        }

        var pool = _unitOfWork.Repository<Vocabulary>().Query()
            .Where(word => word.DeckId == null
                && word.CategoryId != null
                && categoryIds.Contains(word.CategoryId.Value));

        var progress = _unitOfWork.Repository<UserWordProgress>().Query()
            .Where(row => row.UserID == userId.Value);

        if (mode == "all")
        {
            return Ok(await pool
                .OrderBy(word => word.Term)
                .Take(limit)
                .Select(word => new SessionCardDto
                {
                    WordId = word.WordID,
                    CategoryId = word.CategoryId,
                    Term = word.Term,
                    Translation = word.Translation,
                    ExampleSentence = word.ExampleSentence,
                    ImageUrl = word.ImageUrl,
                    AudioUrl = word.AudioUrl,
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
                    && pool.Any(word => word.WordID == row.WordID))
                .OrderBy(row => row.NextReviewDate)
                .Take(limit)
                .Select(row => new SessionCardDto
                {
                    WordId = row.Vocabulary!.WordID,
                    CategoryId = row.Vocabulary.CategoryId,
                    Term = row.Vocabulary.Term,
                    Translation = row.Vocabulary.Translation,
                    ExampleSentence = row.Vocabulary.ExampleSentence,
                    ImageUrl = row.Vocabulary.ImageUrl,
                    AudioUrl = row.Vocabulary.AudioUrl,
                    MasteryLevel = row.MasteryLevel,
                    IsNew = false
                })
                .ToListAsync());
        }

        if (mode is "new" or "mixed" && cards.Count < limit)
        {
            cards.AddRange(await pool
                .Where(word => !progress.Any(row => row.WordID == word.WordID))
                .OrderBy(word => word.WordID)
                .Take(limit - cards.Count)
                .Select(word => new SessionCardDto
                {
                    WordId = word.WordID,
                    CategoryId = word.CategoryId,
                    Term = word.Term,
                    Translation = word.Translation,
                    ExampleSentence = word.ExampleSentence,
                    ImageUrl = word.ImageUrl,
                    AudioUrl = word.AudioUrl,
                    MasteryLevel = 0,
                    IsNew = true
                })
                .ToListAsync());
        }

        return Ok(cards);
    }

    /// <summary>
    /// Seçili kategorilerde kaç yeni ve kaç zamanı gelmiş kelime olduğu.
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

        var categoryIds = await SelectedCategoryIdsAsync(userId.Value);
        if (categoryIds.Count == 0)
        {
            return Ok(new SessionCountsDto());
        }

        var pool = _unitOfWork.Repository<Vocabulary>().Query()
            .Where(word => word.DeckId == null
                && word.CategoryId != null
                && categoryIds.Contains(word.CategoryId.Value));

        var progress = _unitOfWork.Repository<UserWordProgress>().Query()
            .Where(row => row.UserID == userId.Value);

        var now = DateTime.UtcNow;

        return Ok(new SessionCountsDto
        {
            SelectedCategories = categoryIds.Count,
            NewAvailable = await pool.CountAsync(word => !progress.Any(row => row.WordID == word.WordID)),
            DueCount = await progress.CountAsync(row => row.NextReviewDate != null
                && row.NextReviewDate <= now
                && pool.Any(word => word.WordID == row.WordID))
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

        var deckIds = deckId is not null
            ? new[] { deckId.Value }
            : (await _unitOfWork.Repository<Deck>()
                    .FindAsync(deck => deck.UserId == userId.Value))
                .Select(deck => deck.Id)
                .ToArray();

        // A deckless card is reviewable only when it belongs to the shared lesson
        // curriculum. Orphaned deckless records are never exposed for review.
        var includeCurriculum = deckId is null;
        var curriculumWordIds = includeCurriculum
            ? (await _unitOfWork.Repository<LessonVocabulary>().GetAllAsync())
                .Select(link => link.WordID)
                .Distinct()
                .ToArray()
            : Array.Empty<int>();

        var words = await _unitOfWork.Repository<Vocabulary>()
            .FindAsync(word =>
                (word.DeckId != null && deckIds.Contains(word.DeckId.Value)) ||
                (includeCurriculum && word.DeckId == null && curriculumWordIds.Contains(word.WordID)));
        var now = DateTime.UtcNow;
        var progressesByWord = (await _unitOfWork.Repository<UserWordProgress>()
                .FindAsync(progress => progress.UserID == userId.Value))
            .ToDictionary(progress => progress.WordID);

        return Ok(words
            .Where(word => !progressesByWord.TryGetValue(word.WordID, out var progress) ||
                progress.NextReviewDate is null || progress.NextReviewDate <= now)
            .OrderBy(word => progressesByWord.TryGetValue(word.WordID, out var progress)
                ? progress.NextReviewDate ?? DateTime.MinValue
                : DateTime.MinValue)
            .Take(take)
            .Select(word =>
            {
                progressesByWord.TryGetValue(word.WordID, out var progress);
                return new
                {
                    WordId = word.WordID,
                    word.DeckId,
                    word.Term,
                    word.Translation,
                    word.ExampleSentence,
                    word.ImageUrl,
                    word.AudioUrl,
                    MasteryLevel = progress?.MasteryLevel ?? 0,
                    ReviewCount = progress?.ReviewCount ?? 0,
                    IntervalDays = progress?.IntervalDays ?? 0,
                    EaseFactor = progress?.EaseFactor ?? 2.5,
                    LastRating = progress?.LastRating,
                    NextReviewDate = progress?.NextReviewDate
                };
            }));
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
