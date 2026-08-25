using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Kullanıcının bir quiz oturumu (Figma: Q1 of 5, timer, pts).
/// Soru bankası Quiz tablosunda kalır; oturum skoru burada tutulur.
/// </summary>
public class QuizSession
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? LessonId { get; set; }
    public Lesson? Lesson { get; set; }

    public int? DeckId { get; set; }
    public Deck? Deck { get; set; }

    /// <summary>
    /// Oturumun hangi hedef dilde çözüldüğü. Kart quizinde istemci gönderir ya
    /// da destenin dilinden türetilir; ders quizlerinde boş kalabilir.
    /// </summary>
    [MaxLength(10)]
    public string? LanguageCode { get; set; }

    public int TotalQuestions { get; set; }
    public int CorrectCount { get; set; }
    public int WrongCount { get; set; }
    public int SkippedCount { get; set; }
    public int ScorePoints { get; set; }
    public int TimeLimitSeconds { get; set; } = 20;

    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }

    public ICollection<QuizSessionAnswer> Answers { get; set; } = new List<QuizSessionAnswer>();
}

public class QuizSessionAnswer
{
    public long Id { get; set; }
    public int QuizSessionId { get; set; }
    public QuizSession QuizSession { get; set; } = null!;

    public int? QuizId { get; set; }
    public Quiz? Quiz { get; set; }

    public int? SelectedOptionId { get; set; }
    public QuizOption? SelectedOption { get; set; }

    /// <summary>
    /// Kart quizinde sorunun kelimesi. Ders quizlerinde soru bankadan geldiği
    /// için burası boş, <see cref="QuizId"/> dolu olur.
    /// </summary>
    public int? WordId { get; set; }
    public Vocabulary? Word { get; set; }

    public bool? IsCorrect { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentSeconds { get; set; }
    public int PointsEarned { get; set; }
}
