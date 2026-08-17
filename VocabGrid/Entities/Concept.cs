namespace VocabGrid.Entities;

/// <summary>
/// Dilden bağımsız bir anlam — "merhaba deme", "elma", "yedi" — ve
/// müfredatın gerçek birimi.
///
/// Neden <see cref="Vocabulary"/> yetmiyor: orada bir satır <c>Term</c> ve
/// <c>Translation</c> olmak üzere iki metin taşıyor ve hangi dillerde
/// olduklarını hiçbir yerde yazmıyor. Müfredat bu yüzden örtük olarak
/// İngilizce→Türkçe: "Hallo/Köpek" eklenseydi aynı havuza düşer ve hedef
/// dili ne olursa olsun herkese servis edilirdi.
///
/// Dil kodu sütunu eklemek bunu çözerdi ama içeriği çarpardı: 10 dil, 90
/// yönlü çift demek ve her çift için müfredatın baştan yazılması demek.
/// Kavram modelinde ise her anlam bir kez tanımlanır, her dil bir kez
/// çevrilir (<see cref="ConceptTranslation"/>) ve <em>bütün</em> çiftler
/// aynı satırlardan türer — istemcideki <c>starter_content.dart</c> zaten
/// bu şekilde çalışıyor.
/// </summary>
public class Concept
{
    public int Id { get; set; }

    /// <summary>
    /// İnsan tarafından okunabilen sabit kimlik — "greeting_hello".
    /// Üretilen Id yerine seed dosyaları ve çeviriler bunun üzerinden
    /// eşleşir, böylece araya kavram eklemek sonraki kimlikleri kaydırmaz.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Konu kategorisi — kullanıcının onboarding'de seçtiği kategorilerle
    /// aynı katalog. Kategori kavramda tutulur, çeviride değil: "elma"
    /// hangi dilde olursa olsun yemek kategorisindedir.
    /// </summary>
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    /// <summary>CEFR seviyesi — A1, A2, B1, B2, C1, C2.</summary>
    public string Level { get; set; } = "A1";

    /// <summary>Müfredat içindeki sıra; aynı seviyedeki kavramları sıralar.</summary>
    public int OrderIndex { get; set; }

    public ICollection<ConceptTranslation> Translations { get; set; } = new List<ConceptTranslation>();
}

/// <summary>
/// Bir kavramın tek bir dildeki karşılığı.
///
/// Bir çalışma kartı iki satırdan oluşur: öğrencinin hedef dilindeki satır
/// kartın ön yüzü, ana dilindeki satır arka yüzü. Yani hangi dil çiftinin
/// desteklendiği ayrıca tanımlanmaz — her iki dilde de çevirisi olan her
/// kavram çalışılabilir.
/// </summary>
public class ConceptTranslation
{
    public int ConceptId { get; set; }
    public Concept? Concept { get; set; }

    /// <summary>ISO kodu; <see cref="Language.Code"/> ile aynı küme.</summary>
    public string LanguageCode { get; set; } = string.Empty;
    public Language? Language { get; set; }

    /// <summary>Kelimenin bu dildeki hâli.</summary>
    public string Term { get; set; } = string.Empty;

    /// <summary>
    /// Kelimeyi kullanan örnek cümle, bu dilde. Zorunlu değil: bir dile
    /// önce kelimeler girilip cümleler sonra tamamlanabilsin diye.
    /// </summary>
    public string? ExampleSentence { get; set; }

    /// <summary>Telaffuz sesi; dile özgü olduğu için kavramda değil burada.</summary>
    public string? AudioUrl { get; set; }
}
