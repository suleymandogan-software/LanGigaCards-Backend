using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.DTOs;

/// <summary>
/// Bir kullanıcının tek bir hedef dildeki durumu. Hesap geneli bilgiler
/// <see cref="UserProfileDto"/> içinde; burası "bu dilde neredeyim" sorusunu
/// yanıtlıyor.
/// </summary>
public class LanguageProfileDto
{
    public string LanguageCode { get; set; } = string.Empty;
    public string LanguageName { get; set; } = string.Empty;
    public string ProficiencyLevel { get; set; } = string.Empty;
    public string DifficultyMode { get; set; } = string.Empty;

    /// <summary>
    /// Seviye ölçümü ve kategori seçimi tamamlandı mı. False ise istemci
    /// kurulum penceresini açar; kitaplık o pencerenin sonucuyla kuruluyor.
    /// </summary>
    public bool IsSetupCompleted { get; set; }

    /// <summary>Bu dilde seçilmiş konular.</summary>
    public List<int> CategoryIds { get; set; } = new();

    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public int TotalXp { get; set; }
    public int Level { get; set; }

    public int? LastStudiedDeckId { get; set; }
    public int? LastStudiedWordId { get; set; }
    public DateTime? LastStudiedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

/// <summary>Kurulum penceresinin sonucu: seviye ölçümü ve konu seçimi.</summary>
public class CompleteLanguageSetupDto
{
    [Required]
    [RegularExpression(
        "^(Just Starting|Beginner|Intermediate|Advanced|Fluent)$",
        ErrorMessage = "ProficiencyLevel must be Just Starting, Beginner, Intermediate, Advanced, or Fluent.")]
    public string ProficiencyLevel { get; set; } = string.Empty;

    /// <summary>
    /// Kelime seçimi tavanı. Verilmezse yeterlilik seviyesinden türetilir
    /// (<c>LanguageProgressEngine.DifficultyModeFor</c>).
    /// </summary>
    [RegularExpression(
        @"^$|^(A1|A2|B1|B1\+|B2|C1|C2)$",
        ErrorMessage = "DifficultyMode must be a CEFR level between A1 and C2.")]
    public string? DifficultyMode { get; set; }

    public List<int> CategoryIds { get; set; } = new();
}

public class SwitchTargetLanguageDto
{
    [Required]
    [MaxLength(10)]
    public string LanguageCode { get; set; } = string.Empty;

    /// <summary>
    /// Dilin görünen adı. Verilmezse dil katalogundan okunur; katalogda da
    /// yoksa kodun kendisi kullanılır.
    /// </summary>
    [MaxLength(100)]
    public string? LanguageName { get; set; }
}
