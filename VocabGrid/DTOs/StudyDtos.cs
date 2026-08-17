using System.ComponentModel.DataAnnotations;

namespace VocabGrid.DTOs;

public sealed class UpdateLessonProgressDto
{
    [Range(0, 100)]
    public int Score { get; init; }

    public bool Completed { get; init; }

    [Range(0, 86400)]
    public int StudyDurationSeconds { get; init; }
}
/// <summary>
/// Kategori oturumundaki tek kart. <c>IsNew</c>, kullanıcının bu kelimeyi hiç
/// görmediğini söyler — istemci ilk gösterimde farklı bir rozet çiziyor ve
/// yeni kart sayısı günlük hedefe ayrı sayılıyor.
/// </summary>
public sealed class SessionCardDto
{
    public int WordId { get; init; }
    public int? CategoryId { get; init; }
    public string Term { get; init; } = string.Empty;
    public string Translation { get; init; } = string.Empty;
    public string? ExampleSentence { get; init; }
    public string? ImageUrl { get; init; }
    public string? AudioUrl { get; init; }
    public int MasteryLevel { get; init; }
    public bool IsNew { get; init; }
}

/// <summary>
/// Seçili kategorilerde bekleyen iş miktarı — ana ekrandaki üç mod düğmesi
/// bunu okuyup kendini etkinleştiriyor.
/// </summary>
public sealed class SessionCountsDto
{
    public int SelectedCategories { get; init; }
    public int NewAvailable { get; init; }
    public int DueCount { get; init; }
}

public sealed class SubmitReviewDto
{
    [Required]
    [RegularExpression("^(Again|Hard|Medium|Easy)$", ErrorMessage = "Rating must be Again, Hard, Medium, or Easy.")]
    public string Rating { get; init; } = string.Empty;

    [Range(0, 3600)]
    public int DurationSeconds { get; init; }
}
