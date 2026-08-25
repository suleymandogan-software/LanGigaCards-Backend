using Microsoft.EntityFrameworkCore;

namespace LanGigaCards.Api.Data;

/// <summary>
/// Müfredatın İngilizce ve Türkçe dışındaki çevirileri.
///
/// <b>Yeni bir dil eklemek isteyen buraya bakar.</b> İngilizce ve Türkçe
/// satırlar <see cref="ConceptSeedData"/>'da, çünkü onlar müfredatla birlikte
/// zaten vardı; burası sonradan eklenen diller için.
///
/// Nasıl eklenir:
///
/// 1. Dil <c>Languages</c> katalogunda olmalı (<see cref="CatalogSeedData"/>).
///    Almanca, İspanyolca ve Fransızca zaten orada.
/// 2. Aşağıdaki sözlüğe kavram anahtarı → (kelime, örnek cümle) girin.
///    Anahtarların tam listesi <see cref="ConceptSeedData"/>'daki
///    <c>Concepts</c> dizisinde; "greetings_hello", "food_basics_water" gibi.
/// 3. <c>dotnet ef migrations add &lt;Ad&gt;</c> ve <c>database update</c>.
///
/// Bir dili kısmen doldurmak sorun değil: bir kavramın yalnızca bazı
/// dillerde çevirisi olabilir. Çalışma oturumu, öğrencinin <em>hem</em> hedef
/// <em>hem</em> ana dilinde çevirisi olan kavramları getirir, gerisini
/// sessizce atlar. Yani 20 kelimeyle başlayıp zamanla büyütebilirsiniz.
///
/// Örnek cümle boş bırakılabilir (<c>null</c>); kart örneksiz gösterilir.
/// Kelime boş bırakılamaz — CHECK kısıtı reddeder.
/// </summary>
internal static class ConceptTranslationSeedData
{
    /// <summary>Tek bir dildeki çeviri: kelime ve isteğe bağlı örnek cümle.</summary>
    private readonly record struct Entry(string Term, string? Example = null);

    /// <summary>
    /// Dil kodu → (kavram anahtarı → çeviri).
    ///
    /// Şu an her dilde yalnızca ilk ders (Greetings) dolu. Bu bir örnek
    /// değil, çalışan içerik: Almanca öğrenen bir Türk bugün bu 12 kartı
    /// çalışabiliyor. Gerisi doldurulacak.
    /// </summary>
    private static readonly Dictionary<string, Dictionary<string, Entry>> ByLanguage = new()
    {
        ["de"] = new()
        {
            ["greetings_hello"] = new("Hallo", "Hallo, schön dich kennenzulernen."),
            ["greetings_good_morning"] = new("Guten Morgen", "Guten Morgen, hast du gut geschlafen?"),
            ["greetings_good_evening"] = new("Guten Abend", "Guten Abend, kommen Sie bitte herein."),
            ["greetings_good_night"] = new("Gute Nacht", "Gute Nacht, bis morgen."),
            ["greetings_goodbye"] = new("Auf Wiedersehen", "Auf Wiedersehen, pass auf dich auf."),
            ["greetings_thank_you"] = new("Danke", "Danke für deine ganze Hilfe."),
            ["greetings_please"] = new("Bitte", "Bitte warten Sie hier einen Moment."),
            ["greetings_sorry"] = new("Entschuldigung", "Entschuldigung, ich komme zu spät."),
            ["greetings_excuse_me"] = new("Entschuldigen Sie", "Entschuldigen Sie, wo ist der Bahnhof?"),
            ["greetings_yes"] = new("Ja", "Ja, das klingt gut für mich."),
            ["greetings_no"] = new("Nein", "Nein, vielen Dank."),
            ["greetings_welcome"] = new("Willkommen", "Willkommen in unserem Haus."),
        },
        ["es"] = new()
        {
            ["greetings_hello"] = new("Hola", "Hola, encantado de conocerte."),
            ["greetings_good_morning"] = new("Buenos días", "Buenos días, ¿has dormido bien?"),
            ["greetings_good_evening"] = new("Buenas tardes", "Buenas tardes, pase usted."),
            ["greetings_good_night"] = new("Buenas noches", "Buenas noches, hasta mañana."),
            ["greetings_goodbye"] = new("Adiós", "Adiós, cuídate mucho."),
            ["greetings_thank_you"] = new("Gracias", "Gracias por toda tu ayuda."),
            ["greetings_please"] = new("Por favor", "Por favor, espere aquí un momento."),
            ["greetings_sorry"] = new("Lo siento", "Lo siento, voy con retraso."),
            ["greetings_excuse_me"] = new("Perdone", "Perdone, ¿dónde está la estación?"),
            ["greetings_yes"] = new("Sí", "Sí, me parece bien."),
            ["greetings_no"] = new("No", "No, muchas gracias."),
            ["greetings_welcome"] = new("Bienvenido", "Bienvenido a nuestra casa."),
        },
        ["fr"] = new()
        {
            ["greetings_hello"] = new("Bonjour", "Bonjour, enchanté de vous rencontrer."),
            ["greetings_good_morning"] = new("Bonjour", "Bonjour, avez-vous bien dormi ?"),
            ["greetings_good_evening"] = new("Bonsoir", "Bonsoir, entrez je vous prie."),
            ["greetings_good_night"] = new("Bonne nuit", "Bonne nuit, à demain."),
            ["greetings_goodbye"] = new("Au revoir", "Au revoir, prenez soin de vous."),
            ["greetings_thank_you"] = new("Merci", "Merci pour toute votre aide."),
            ["greetings_please"] = new("S'il vous plaît", "S'il vous plaît, attendez ici un instant."),
            ["greetings_sorry"] = new("Désolé", "Désolé, je suis en retard."),
            ["greetings_excuse_me"] = new("Excusez-moi", "Excusez-moi, où est la gare ?"),
            ["greetings_yes"] = new("Oui", "Oui, cela me convient."),
            ["greetings_no"] = new("Non", "Non, merci beaucoup."),
            ["greetings_welcome"] = new("Bienvenue", "Bienvenue chez nous."),
        },
    };

    /// <remarks>
    /// <c>conceptKeys</c>, <see cref="ConceptSeedData"/>'daki kavram
    /// anahtarlarıdır, sırasıyla — kimlikler bu dizideki konumdan türüyor.
    /// Buradaki bir yazım hatası sessizce eksik çeviriye dönüşmesin diye,
    /// eşleşmeyen anahtar açılışta istisna fırlatır.
    /// </remarks>
    internal static void Apply(ModelBuilder modelBuilder, string[] conceptKeys)
    {
        var idByKey = conceptKeys
            .Select((key, index) => (key, id: index + 1))
            .ToDictionary(x => x.key, x => x.id);

        var rows = new List<ConceptTranslation>();
        foreach (var (languageCode, entries) in ByLanguage)
        {
            foreach (var (conceptKey, entry) in entries)
            {
                if (!idByKey.TryGetValue(conceptKey, out var conceptId))
                {
                    throw new InvalidOperationException(
                        $"'{languageCode}' çevirisi bilinmeyen bir kavrama işaret ediyor: '{conceptKey}'. " +
                        "Anahtarlar ConceptSeedData.Concepts ile birebir eşleşmeli.");
                }

                rows.Add(new ConceptTranslation
                {
                    ConceptId = conceptId,
                    LanguageCode = languageCode,
                    Term = entry.Term,
                    ExampleSentence = entry.Example
                });
            }
        }

        modelBuilder.Entity<ConceptTranslation>().HasData(rows);
    }
}
