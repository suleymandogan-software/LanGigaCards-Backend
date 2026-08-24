using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanGigaCards.Api.DTOs;
using LanGigaCards.Api.Services;

namespace LanGigaCards.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class QuizController : ControllerBase
{
    private const int LessonCompletionScore = 80;
    private readonly IUnitOfWork _unitOfWork;

    public QuizController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("questions")]
    public async Task<IActionResult> GetQuestions([FromQuery] int lessonId, [FromQuery] int count = 5)
    {
        if (lessonId <= 0 || count is < 1 or > 50)
        {
            return BadRequest("LessonId must be positive and count must be between 1 and 50.");
        }

        var questions = (await _unitOfWork.Repository<Quiz>()
                .FindAsync(quiz => quiz.LessonID == lessonId))
            .OrderBy(_ => Random.Shared.Next())
            .Take(count)
            .ToList();

        if (questions.Count == 0)
        {
            return NotFound("No quiz questions are available for this lesson.");
        }

        return Ok(await BuildQuestionPayloadsAsync(questions));
    }

    [HttpPost("sessions")]
    public async Task<IActionResult> StartSession([FromBody] StartQuizSessionDto dto)
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

        var lesson = await _unitOfWork.Repository<Lesson>().GetByIdAsync(dto.LessonId);
        if (lesson is null)
        {
            return NotFound("Lesson not found.");
        }

        var questions = (await _unitOfWork.Repository<Quiz>()
                .FindAsync(quiz => quiz.LessonID == dto.LessonId))
            .OrderBy(_ => Random.Shared.Next())
            .Take(dto.QuestionCount)
            .ToList();

        if (questions.Count < dto.QuestionCount)
        {
            return BadRequest($"Only {questions.Count} question(s) are available for this lesson.");
        }

        var session = new QuizSession
        {
            UserId = userId.Value,
            LessonId = lesson.LessonID,
            TotalQuestions = questions.Count,
            StartedAt = DateTime.UtcNow,
            // Persist the selected set before any answer can be submitted. This prevents a
            // client from submitting an arbitrary question from the same lesson later.
            Answers = questions.Select(question => new QuizSessionAnswer
            {
                QuizId = question.QuizID
            }).ToList()
        };

        await _unitOfWork.Repository<QuizSession>().AddAsync(session);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetSession), new { sessionId = session.Id }, new
        {
            SessionId = session.Id,
            session.TotalQuestions,
            session.TimeLimitSeconds,
            Questions = await BuildQuestionPayloadsAsync(questions)
        });
    }

    [HttpGet("sessions/{sessionId:int}")]
    public async Task<IActionResult> GetSession(int sessionId)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var session = (await _unitOfWork.Repository<QuizSession>()
                .FindAsync(candidate => candidate.Id == sessionId && candidate.UserId == userId.Value))
            .FirstOrDefault();
        if (session is null)
        {
            return NotFound("Quiz session not found.");
        }

        var answers = (await _unitOfWork.Repository<QuizSessionAnswer>()
                .FindAsync(answer => answer.QuizSessionId == session.Id))
            .OrderBy(answer => answer.Id)
            .ToList();

        return Ok(new
        {
            SessionId = session.Id,
            session.LessonId,
            session.TotalQuestions,
            session.CorrectCount,
            session.WrongCount,
            session.SkippedCount,
            session.ScorePoints,
            session.StartedAt,
            session.CompletedAt,
            AnsweredQuestions = answers.Count(IsAnswered),
            Answers = answers.Select(answer => new
            {
                answer.QuizId,
                answer.SelectedOptionId,
                answer.IsCorrect,
                answer.IsSkipped,
                answer.TimeSpentSeconds,
                answer.PointsEarned
            })
        });
    }

    [HttpPost("sessions/{sessionId:int}/answers")]
    public async Task<IActionResult> SubmitAnswer(int sessionId, [FromBody] SubmitQuizAnswerDto dto)
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

        if (!dto.Skip && dto.SelectedOptionId is null)
        {
            return BadRequest("SelectedOptionId is required unless the question is skipped.");
        }

        var session = (await _unitOfWork.Repository<QuizSession>()
                .FindAsync(candidate => candidate.Id == sessionId && candidate.UserId == userId.Value))
            .FirstOrDefault();
        if (session is null)
        {
            return NotFound("Quiz session not found.");
        }

        if (session.CompletedAt is not null)
        {
            return BadRequest("This quiz session has already been completed.");
        }

        var answerRepository = _unitOfWork.Repository<QuizSessionAnswer>();
        var existingAnswers = (await answerRepository.FindAsync(answer => answer.QuizSessionId == session.Id)).ToList();
        var sessionAnswer = existingAnswers.FirstOrDefault(answer => answer.QuizId == dto.QuizId);
        if (sessionAnswer is null)
        {
            return BadRequest("The question is not part of this quiz session.");
        }

        if (IsAnswered(sessionAnswer))
        {
            return BadRequest("This question has already been answered in the session.");
        }

        var quiz = await _unitOfWork.Repository<Quiz>().GetByIdAsync(dto.QuizId);
        if (quiz is null || quiz.LessonID != session.LessonId)
        {
            return BadRequest("The question does not belong to this quiz session.");
        }

        QuizOption? selectedOption = null;
        if (!dto.Skip)
        {
            selectedOption = await _unitOfWork.Repository<QuizOption>().GetByIdAsync(dto.SelectedOptionId!.Value);
            if (selectedOption is null || selectedOption.QuizID != quiz.QuizID)
            {
                return BadRequest("The selected option does not belong to this question.");
            }
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var isCorrect = !dto.Skip && selectedOption!.IsCorrect;
        var pointsEarned = isCorrect ? quiz.Points : 0;
        var submittedAt = DateTime.UtcNow;

        sessionAnswer.SelectedOptionId = selectedOption?.OptionID;
        sessionAnswer.IsCorrect = dto.Skip ? null : isCorrect;
        sessionAnswer.IsSkipped = dto.Skip;
        sessionAnswer.TimeSpentSeconds = dto.TimeSpentSeconds;
        sessionAnswer.PointsEarned = pointsEarned;
        answerRepository.Update(sessionAnswer);

        if (dto.Skip)
        {
            session.SkippedCount++;
        }
        else if (isCorrect)
        {
            session.CorrectCount++;
        }
        else
        {
            session.WrongCount++;
        }

        session.ScorePoints += pointsEarned;
        var isComplete = existingAnswers.All(IsAnswered);
        if (isComplete)
        {
            session.CompletedAt = submittedAt;
            await UpdateLessonProgressFromQuizAsync(user.Id, session, submittedAt);
        }

        _unitOfWork.Repository<QuizSession>().Update(session);

        var activity = new StudyActivity
        {
            UserId = user.Id,
            LessonId = session.LessonId,
            DeckId = session.DeckId,
            OccurredAt = submittedAt,
            ActivityType = "Quiz",
            // Oturum kendi dilini taşıyorsa ondan, taşımıyorsa (eski ders
            // quizleri) öğrenenin o anki hedef dilinden.
            LanguageCode = string.IsNullOrWhiteSpace(session.LanguageCode)
                ? await LanguageCodeResolver.ResolveAsync(_unitOfWork, user.TargetLanguageCode)
                : session.LanguageCode,
            Result = dto.Skip ? "Skipped" : isCorrect ? "Correct" : "Wrong",
            DurationSeconds = dto.TimeSpentSeconds,
            XpEarned = pointsEarned
        };
        await _unitOfWork.Repository<StudyActivity>().AddAsync(activity);
        await DailySummaryEngine.RecordAsync(_unitOfWork, activity);
        await LanguageProgressEngine.RecordAsync(_unitOfWork, activity, user.TargetLanguage);

        StudyEngine.ApplyXp(user, pointsEarned);
        await StudyEngine.UpdateStreakAsync(_unitOfWork, user, submittedAt);

        var newlyUnlocked = isComplete
            ? await AchievementEvaluator.UnlockEligibleAsync(_unitOfWork, user, activity)
            : Array.Empty<Badge>();

        // So clients can highlight the right option after a wrong/skip answer
        // without a second round-trip (options payloads never include IsCorrect).
        var correctOptionId = (await _unitOfWork.Repository<QuizOption>()
                .FindAsync(option => option.QuizID == quiz.QuizID && option.IsCorrect))
            .Select(option => (int?)option.OptionID)
            .FirstOrDefault();

        await _unitOfWork.CompleteAsync();

        return Ok(new
        {
            IsCorrect = dto.Skip ? (bool?)null : isCorrect,
            dto.Skip,
            pointsEarned,
            CorrectOptionId = correctOptionId,
            session.CorrectCount,
            session.WrongCount,
            session.SkippedCount,
            session.ScorePoints,
            IsComplete = isComplete,
            NewlyUnlockedAchievements = newlyUnlocked.Select(badge => new { badge.Id, badge.Name, badge.Description, badge.Icon })
        });
    }

    private async Task UpdateLessonProgressFromQuizAsync(int userId, QuizSession session, DateTime completedAt)
    {
        if (session.LessonId is null || session.TotalQuestions == 0)
        {
            return;
        }

        var progressRepository = _unitOfWork.Repository<UserProgress>();
        var progress = (await progressRepository.FindAsync(candidate =>
                candidate.UserID == userId && candidate.LessonID == session.LessonId.Value))
            .FirstOrDefault();
        var score = (int)Math.Round(session.CorrectCount * 100.0 / session.TotalQuestions);

        if (progress is null)
        {
            await progressRepository.AddAsync(new UserProgress
            {
                UserID = userId,
                LessonID = session.LessonId.Value,
                Score = score,
                Completed = score >= LessonCompletionScore,
                LastAccess = completedAt
            });
            return;
        }

        progress.Score = Math.Max(progress.Score, score);
        progress.Completed |= score >= LessonCompletionScore;
        progress.LastAccess = completedAt;
        progressRepository.Update(progress);
    }

    private async Task<IEnumerable<object>> BuildQuestionPayloadsAsync(IEnumerable<Quiz> questions)
    {
        var questionList = questions.ToList();
        var questionIds = questionList.Select(question => question.QuizID).ToList();
        var options = await _unitOfWork.Repository<QuizOption>()
            .FindAsync(option => questionIds.Contains(option.QuizID));
        var optionsByQuestion = options.ToLookup(option => option.QuizID);

        return questionList.Select(question => (object)new
        {
            QuizId = question.QuizID,
            question.QuestionText,
            question.QuestionType,
            question.ImageUrl,
            question.Points,
            question.TimeLimitSeconds,
            Options = optionsByQuestion[question.QuizID]
                .OrderBy(option => option.OptionID)
                .Select(option => new { OptionId = option.OptionID, option.OptionText })
        });
    }

    private static bool IsAnswered(QuizSessionAnswer answer)
        => answer.IsSkipped || answer.IsCorrect.HasValue;

    private int? TryGetUserId()
    {
        var raw = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(raw, out var id) ? id : null;
    }

    /// <summary>
    /// İstemcide öğrenenin kendi kartlarından üretilen quizin sonucunu kaydeder.
    ///
    /// <para>
    /// Doğruluk bu quizin başarısıdır: atlanan sorular paydaya girmez, çünkü
    /// cevaplanmamış bir soru ne bilindi ne bilinmedi.
    /// </para>
    ///
    /// <para>
    /// Tamamlama ise birikimlidir ve gösterilen ayrı kelime sayısına bakar:
    /// kapsamdaki kaç kelime bugüne kadar quizde önüne çıktı. Doğru bilinip
    /// bilinmemesi tamamlamayı etkilemez; o zaten doğruluğun ölçtüğü şey.
    /// </para>
    ///
    /// <para>
    /// Ders quizlerinden ayrı bir yol: orada sorular sunucudaki bankadan gelir
    /// ve tek tek doğrulanır. Burada sorular istemcide üretiliyor, sunucuda
    /// karşılığı yok; doğrulanabilecek tek şey kelimelerin gerçekten
    /// kullanıcıya ait olduğu.
    /// </para>
    /// </summary>
    [HttpPost("card-sessions")]
    public async Task<IActionResult> SubmitCardQuiz([FromBody] SubmitCardQuizDto dto)
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

        Deck? deck = null;
        if (dto.DeckId is not null)
        {
            deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(dto.DeckId.Value);
            if (deck is null || deck.UserId != user.Id)
            {
                return NotFound("Deck not found.");
            }
        }

        var languageCode = await LanguageCodeResolver.ResolveAsync(_unitOfWork, dto.LanguageCode);
        if (languageCode.Length == 0)
        {
            languageCode = await LanguageCodeResolver.ResolveAsync(_unitOfWork, deck?.LanguageCode);
        }

        if (languageCode.Length == 0)
        {
            languageCode = await LanguageCodeResolver.ResolveAsync(_unitOfWork, user.TargetLanguageCode);
        }

        // Yalnızca kullanıcının kendi kartları sayılır. İstemci kendi
        // kitaplığından ürettiği için normalde hepsi geçer; süzgeç, uydurulmuş
        // bir kelime kimliğinin başkasının kartını istatistiğe sokmasını
        // engelliyor.
        var answeredIds = dto.Answers.Select(answer => answer.WordId).Distinct().ToList();
        var ownedWords = await _unitOfWork.Repository<Vocabulary>().Query()
            .Where(word => answeredIds.Contains(word.WordID)
                           && word.DeckId != null
                           && word.Deck!.UserId == user.Id)
            .Select(word => new { word.WordID, word.DeckId })
            .ToListAsync();
        var deckByWord = ownedWords.ToDictionary(word => word.WordID, word => word.DeckId);

        var answers = dto.Answers.Where(answer => deckByWord.ContainsKey(answer.WordId)).ToList();
        if (answers.Count == 0)
        {
            return BadRequest("None of the submitted words belong to the signed-in user.");
        }

        var completedAt = DateTime.UtcNow;
        var graded = answers.Where(answer => !answer.Skipped).ToList();
        var correctCount = graded.Count(answer => answer.IsCorrect);

        var session = new QuizSession
        {
            UserId = user.Id,
            DeckId = deck?.Id,
            LanguageCode = languageCode,
            TotalQuestions = answers.Count,
            CorrectCount = correctCount,
            WrongCount = graded.Count - correctCount,
            SkippedCount = answers.Count - graded.Count,
            ScorePoints = correctCount,
            StartedAt = completedAt.AddSeconds(-answers.Sum(answer => answer.TimeSpentSeconds)),
            CompletedAt = completedAt,
            Answers = answers.Select(answer => new QuizSessionAnswer
            {
                WordId = answer.WordId,
                IsCorrect = answer.Skipped ? null : answer.IsCorrect,
                IsSkipped = answer.Skipped,
                TimeSpentSeconds = answer.TimeSpentSeconds,
                PointsEarned = !answer.Skipped && answer.IsCorrect ? 1 : 0
            }).ToList()
        };
        await _unitOfWork.Repository<QuizSession>().AddAsync(session);

        // Soru başına bir aktivite. Tamamlama ölçüsü "kaç ayrı kelime
        // gösterildi" sorusunu soruyor ve bunu yanıtlayabilmek için hangi
        // kelimelerin göründüğü kaydedilmek zorunda — oturum başına tek bir
        // özet satırı bu bilgiyi taşıyamaz.
        var activities = answers.Select(answer => new StudyActivity
        {
            UserId = user.Id,
            WordId = answer.WordId,
            DeckId = deckByWord[answer.WordId],
            OccurredAt = completedAt,
            ActivityType = "Quiz",
            LanguageCode = languageCode,
            Result = answer.Skipped ? "Skipped" : answer.IsCorrect ? "Correct" : "Wrong",
            DurationSeconds = answer.TimeSpentSeconds,
            XpEarned = !answer.Skipped && answer.IsCorrect ? 1 : 0
        }).ToList();

        foreach (var activity in activities)
        {
            await _unitOfWork.Repository<StudyActivity>().AddAsync(activity);
        }

        await DailySummaryEngine.RecordManyAsync(_unitOfWork, activities);
        await LanguageProgressEngine.RecordManyAsync(_unitOfWork, activities, user.TargetLanguage);

        var xpEarned = activities.Sum(activity => activity.XpEarned);
        StudyEngine.ApplyXp(user, xpEarned);
        await StudyEngine.UpdateStreakAsync(_unitOfWork, user, completedAt);

        var newlyUnlocked = await AchievementEvaluator.UnlockEligibleAsync(_unitOfWork, user, activities[^1]);
        await _unitOfWork.CompleteAsync();

        var completion = await ComputeCompletionAsync(user.Id, deck?.Id, languageCode);

        return Ok(new
        {
            SessionId = session.Id,
            session.TotalQuestions,
            session.CorrectCount,
            session.WrongCount,
            session.SkippedCount,
            // Bu quizin doğruluğu. Atlanan sorular paydada yok.
            AccuracyPercent = graded.Count == 0 ? 0 : Math.Round(correctCount * 100.0 / graded.Count, 1),
            AnsweredQuestions = graded.Count,
            // Tamamlama: kapsamdaki kaç ayrı kelime bugüne kadar gösterildi.
            completion.WordsSeen,
            completion.WordsInScope,
            CompletionPercent = completion.Percent,
            XpEarned = xpEarned,
            NewlyUnlockedAchievements = newlyUnlocked.Select(badge => new { badge.Id, badge.Name, badge.Description, badge.Icon })
        });
    }

    /// <summary>
    /// Quiz tamamlama durumu — quiz çözmeden, yalnızca göstermek için. Quiz
    /// ekranı bunu açılışta okur; sonuç ekranındaki tamamlama ise gönderim
    /// yanıtından gelir. İkisi aynı hesabı kullanır.
    /// </summary>
    [HttpGet("card-completion")]
    public async Task<IActionResult> GetCardCompletion(
        [FromQuery] int? deckId,
        [FromQuery] string? languageCode)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (deckId is not null)
        {
            var deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(deckId.Value);
            if (deck is null || deck.UserId != userId.Value)
            {
                return NotFound("Deck not found.");
            }
        }

        var code = await LanguageCodeResolver.ResolveAsync(_unitOfWork, languageCode);
        if (code.Length == 0)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
            code = await LanguageCodeResolver.ResolveAsync(_unitOfWork, user?.TargetLanguageCode);
        }

        var completion = await ComputeCompletionAsync(userId.Value, deckId, code);
        return Ok(new
        {
            completion.WordsSeen,
            completion.WordsInScope,
            CompletionPercent = completion.Percent
        });
    }

    /// <summary>
    /// Kapsamdaki kelimelerin kaçının quizde gösterildiğini hesaplar.
    ///
    /// Kapsam bir desteyse o destenin kartları, değilse kullanıcının o dildeki
    /// bütün kartları. "Gösterildi" ölçüsü quiz aktivitelerindeki ayrı kelime
    /// kimliklerinden çıkıyor; aynı kelimeyi ikinci kez görmek tamamlamayı
    /// ilerletmez.
    /// </summary>
    private async Task<(int WordsSeen, int WordsInScope, double Percent)> ComputeCompletionAsync(
        int userId,
        int? deckId,
        string languageCode)
    {
        var scope = _unitOfWork.Repository<Vocabulary>().Query()
            .Where(word => word.DeckId != null && word.Deck!.UserId == userId);

        scope = deckId is not null
            ? scope.Where(word => word.DeckId == deckId)
            : scope.Where(word => word.Deck!.LanguageCode == languageCode);

        var wordsInScope = await scope.CountAsync();
        if (wordsInScope == 0)
        {
            return (0, 0, 0);
        }

        var seenIds = _unitOfWork.Repository<StudyActivity>().Query()
            .Where(activity => activity.UserId == userId
                               && activity.ActivityType == "Quiz"
                               && activity.WordId != null)
            .Select(activity => activity.WordId!.Value);

        var wordsSeen = await scope.Where(word => seenIds.Contains(word.WordID)).CountAsync();

        return (wordsSeen, wordsInScope, Math.Round(wordsSeen * 100.0 / wordsInScope, 1));
    }
}
