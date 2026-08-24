using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Bir şablonun içerdiği tek bir kavram ve şablon içindeki sırası.
///
/// Kelime metni burada durmaz — <see cref="Concept"/> ve
/// <see cref="ConceptTranslation"/> zaten dilden bağımsız anlamı ve dil başına
/// karşılığını tutuyor. Şablonun kendi kelime tablosunu taşıması, aynı içeriğin
/// ikinci bir kopyası olurdu ve ikisi zamanla ayrışırdı.
///
/// Üyeliğin ayrı bir tablo olması ise gerekli: şablonun kelimelerini
/// "kategorisi bu şablonunkiyle aynı olan kavramlar" diye türetmek yetmiyor.
/// Katalogda bilerek başka kategoriden alınmış kelimeler var (teknoloji
/// destesindeki "Cloud" kavram olarak doğa/hava kategorisinde durur) ve aynı
/// kavram birden çok şablonda geçebiliyor. Sıra da şablona özgü: kavramın
/// müfredat içindeki <c>OrderIndex</c>'i, destede görünmesi istenen sırayla
/// aynı olmak zorunda değil.
/// </summary>
public class DeckTemplateConcept
{
    public int DeckTemplateId { get; set; }
    public DeckTemplate? DeckTemplate { get; set; }

    public int ConceptId { get; set; }
    public Concept? Concept { get; set; }

    /// <summary>Deste içindeki sıra (1'den başlar).</summary>
    public int Ordinal { get; set; }

    /// <summary>
    /// Kelimenin bu şablondaki CEFR kademesi: <c>A1</c>, <c>A2</c>, <c>B1</c>,
    /// <c>B1+</c>, <c>B2</c>, <c>C1</c>, <c>C2</c>. İstemcideki
    /// <c>DifficultyMode</c> enum'ıyla aynı etiketler.
    ///
    /// Deste kurulurken öğrenenin seçtiği seviye <em>ve altı</em> alınır: CEFR
    /// birikimlidir, B2 çalışan biri A1 kelimesini de bilmek durumundadır. Her
    /// şablonda kademe başına sabit bir kota var (A1 10, A2 7, B1 6, B1+ 4,
    /// B2 4, C1 3, C2 2), yani destenin boyu seviyeye göre öngörülebilir
    /// biçimde büyüyor.
    ///
    /// Kademe <see cref="Concept.Level"/>'da değil burada duruyor, çünkü bu
    /// kavramın kendi özelliği değil şablon içindeki rolü: aynı kavram başka
    /// bir şablonda farklı bir kademede olabilir, üstelik müfredattan gelen
    /// kavramların <c>Level</c>'ı dersin seviyesinden türemiş durumda ve onu
    /// kotaya uydurmak için değiştirmek o veriyi bozardı.
    /// </summary>
    [MaxLength(4)]
    public string CefrLevel { get; set; } = "A1";
}
