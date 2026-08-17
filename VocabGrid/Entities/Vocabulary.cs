using System.ComponentModel.DataAnnotations;

namespace VocabGrid.Entities;

/// <summary>
/// Flashcard içeriği.
/// FRONT = Term, BACK = Translation, IMAGE URL = ImageUrl (Figma Add Card).
/// </summary>
public class Vocabulary
{
    [Key]
    public int WordID { get; set; }

    public int? DeckId { get; set; }
    public Deck? Deck { get; set; }

    /// <summary>
    /// Kelimenin konu kategorisi. Onboarding'de seçilen kategoriler
    /// (<see cref="UserCategory"/>) çalışma oturumunu bu sütun üzerinden
    /// filtreler; kategori seçimi bu bağ kurulmadan önce hiçbir sorguya
    /// girmiyordu.
    ///
    /// Null olabilir: öğrencinin kendi destesine eklediği kart bir kategoriye
    /// ait olmak zorunda değil. Böyle kartlar kategori oturumuna girmez,
    /// kendi destesinden çalışılır.
    /// </summary>
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    /// <summary>FRONT (target word)</summary>
    public string Term { get; set; } = string.Empty;

    /// <summary>BACK (translation)</summary>
    public string Translation { get; set; } = string.Empty;

    public string? ExampleSentence { get; set; }

    /// <summary>Kart görseli (URL veya upload sonrası public path).</summary>
    public string? ImageUrl { get; set; }

    public string? AudioUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<LessonVocabulary> LessonVocabularies { get; set; } = new List<LessonVocabulary>();
    public ICollection<UserWordProgress> UserWordProgresses { get; set; } = new List<UserWordProgress>();
    public ICollection<VocabularyTag> VocabularyTags { get; set; } = new List<VocabularyTag>();
}
