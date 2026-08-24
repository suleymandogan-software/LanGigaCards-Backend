using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Bir şablonun tek bir dildeki adı ve açıklaması.
///
/// Öğrenenin kendi (ana) diline göre seçilir, hedef diline göre değil: Almanca
/// çalışan bir İngiliz deste listesinde "Technology" görür, "Technik" değil.
/// Deste listesi bir gezinme yüzeyi ve öğrenenin onu akıcı okuyabilmesi
/// gerekiyor; öğrenilen dille asıl temas kartların kendisinde (Term/Translation).
///
/// Karşılığı olmayan dil için çağıran taraf İngilizceye düşer, böylece dil
/// listesine yeni bir dil eklemek adsız deste üretmez.
/// </summary>
public class DeckTemplateLabel
{
    public int DeckTemplateId { get; set; }
    public DeckTemplate? DeckTemplate { get; set; }

    /// <summary><see cref="Language.Code"/> ile aynı ISO kodu (<c>en</c>, <c>ja</c>).</summary>
    [MaxLength(10)]
    public string LanguageCode { get; set; } = string.Empty;

    /// <summary><c>Deck.Title</c> ile aynı sınırda tutulur.</summary>
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
}
