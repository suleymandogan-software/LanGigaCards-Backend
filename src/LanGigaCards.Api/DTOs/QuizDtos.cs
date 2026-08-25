using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.DTOs;

public sealed class StartQuizSessionDto
{
    [Range(1, int.MaxValue)]
    public int LessonId { get; init; }

    [Range(1, 50)]
    public int QuestionCount { get; init; } = 5;
}
public sealed class SubmitQuizAnswerDto
{
    [Range(1, int.MaxValue)]
    public int QuizId { get; init; }

    [Range(1, int.MaxValue)]
    public int? SelectedOptionId { get; init; }

    public bool Skip { get; init; }

    [Range(0, 3600)]
    public int TimeSpentSeconds { get; init; }
}

/// <summary>
/// İstemcide öğrenenin kendi kartlarından üretilen quizin sonucu.
///
/// Ders quizlerinden ayrı bir yol: orada sorular sunucudaki bankadan gelir ve
/// tek tek doğrulanır. Burada sunucunun doğrulayabileceği tek şey kelimelerin
/// gerçekten kullanıcıya ait olduğu.
/// </summary>
public sealed class SubmitCardQuizDto
{
    /// <summary>
    /// Quizin çalışıldığı deste. Null ise quiz tüm kitaplıktan üretilmiştir; o
    /// zaman tamamlama yüzdesi de kitaplığın tamamına göre hesaplanır.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int? DeckId { get; init; }

    /// <summary>
    /// Hedef dil. Boş bırakılırsa destenin dili, o da yoksa kullanıcının o an
    /// çalıştığı dil kullanılır.
    /// </summary>
    [MaxLength(10)]
    public string? LanguageCode { get; init; }

    [MinLength(1, ErrorMessage = "A quiz submission must contain at least one answer.")]
    public List<CardQuizAnswerDto> Answers { get; init; } = new();
}

public sealed class CardQuizAnswerDto
{
    [Range(1, int.MaxValue)]
    public int WordId { get; init; }

    public bool IsCorrect { get; init; }

    /// <summary>
    /// Soru cevaplanmadan süre doldu. Doğru sayılmaz ama yanlış da sayılmaz —
    /// doğruluk oranının paydasına girmez.
    /// </summary>
    public bool Skipped { get; init; }

    [Range(0, 3600)]
    public int TimeSpentSeconds { get; init; }
}
