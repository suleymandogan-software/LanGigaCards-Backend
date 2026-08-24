using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Bir kategoriye ait hazır deste şablonu.
///
/// Şablonun kendisi kullanıcıya ait değildir: <see cref="Deck"/> her zaman bir
/// kullanıcıya bağlıyken (<c>Deck.UserId</c> zorunlu), şablon katalogda tek
/// kopya durur ve kullanıcı o kategoriyi seçtiğinde ona ait bir deste olarak
/// kopyalanır (<c>CategoryDeckSynchronizer</c>). Böylece ilerleme kişiye özel
/// kalır, içerik ise tek yerden güncellenir.
///
/// Başlık ve açıklama dile göre <see cref="DeckTemplateLabel"/>'da; kelimeler
/// ise <see cref="DeckTemplateConcept"/> üzerinden <see cref="Concept"/>'lere
/// bağlanır. Şablonun kendisi dilden bağımsızdır.
/// </summary>
public class DeckTemplate
{
    public int Id { get; set; }

    /// <summary>
    /// İstemcinin desteyi tanıdığı sabit ad (<c>technology</c>, <c>music</c>).
    /// Kullanıcının destesindeki <c>StarterKey</c> bundan türetilir, bu yüzden
    /// bir kez yayınlandıktan sonra değiştirilemez.
    /// </summary>
    [MaxLength(40)]
    public string Slug { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    /// <summary>Deste kartındaki emoji (Flutter <c>Deck.emoji</c>).</summary>
    [MaxLength(16)]
    public string Emoji { get; set; } = string.Empty;

    /// <summary>Vurgu rengi (<c>#06B6D4</c>) — Flutter <c>accentColor</c>.</summary>
    [MaxLength(16)]
    public string ColorHex { get; set; } = string.Empty;

    /// <summary>
    /// Kullanıcı birden çok kategori seçtiğinde destelerin kitaplıkta hangi
    /// sırayla oluşacağı.
    /// </summary>
    public int SortOrder { get; set; }

    public ICollection<DeckTemplateLabel> Labels { get; set; } = new List<DeckTemplateLabel>();
    public ICollection<DeckTemplateConcept> Concepts { get; set; } = new List<DeckTemplateConcept>();
}
