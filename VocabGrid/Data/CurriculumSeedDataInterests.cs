using Microsoft.EntityFrameworkCore;
using VocabGrid.Entities;

namespace VocabGrid.Data;

/// <summary>
/// Müfredatın ilgi alanı bölümü: 21-24. dersler ve 48 kelime.
///
/// Bu blok kategori bağlantısıyla (<see cref="Vocabulary.CategoryId"/>) birlikte
/// eklendi. Katalogdaki 15 kategoriden dördü — Movies, Gaming, Science,
/// Animals — mevcut 20 dersin hiçbirine denk gelmiyordu. Kategori seçimi artık
/// çalışma oturumunu süzdüğü için, yalnızca o dördünü seçen bir öğrenci boş
/// bir oturumla karşılaşırdı: özellik çalışıyor ama içerik yok. Dört ders bu
/// boşluğu kapatıyor ve her kategorinin en az bir dersi olmasını sağlıyor.
///
/// Kelime kimlikleri <see cref="CurriculumSeedDataB1"/>'in bıraktığı yerden,
/// 5121'den devam eder — o dosyadaki kimlik aralığı açıklamasına bakın.
/// Terimler mevcut 238 kelimeyle çakışmayacak şekilde seçildi; aynı terimin
/// iki kez görünmesi tekrar kuyruğunda ayırt edilemeyen bir çift üretirdi.
/// </summary>
internal static class CurriculumSeedDataInterests
{
    private static readonly DateTime SeedCreatedAt = new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc);

    private static readonly (int Id, string Title, string Description, string Level, int Order)[] Lessons =
    {
        (21, "Animals",          "Pets, farm animals and wildlife",          "A2", 21),
        (22, "Science",          "Research, nature's rules and the lab",     "B1", 22),
        (23, "Film and Cinema",  "Watching, describing and discussing film", "B1", 23),
        (24, "Gaming",           "Playing, competing and progressing",       "B1", 24),
    };

    /// <summary>Her dersin katalogdaki kategori karşılığı.</summary>
    private static readonly Dictionary<int, int> LessonCategory = new()
    {
        [21] = 15, // Animals         -> Animals
        [22] = 14, // Science         -> Science
        [23] = 6,  // Film and Cinema -> Movies
        [24] = 8,  // Gaming          -> Gaming
    };

    private static readonly (int WordId, int LessonId, string Term, string Translation, string Example)[] Words =
    {
        // --- Ders 21: Animals ---
        (5121, 21, "Dog",          "Köpek",      "The dog waited by the door."),
        (5122, 21, "Cat",          "Kedi",       "Their cat sleeps all afternoon."),
        (5123, 21, "Bird",         "Kuş",        "A bird built its nest in the tree."),
        (5124, 21, "Fish",         "Balık",      "We caught three fish in the lake."),
        (5125, 21, "Horse",        "At",         "The horse ran across the field."),
        (5126, 21, "Sheep",        "Koyun",      "The sheep stayed close together."),
        (5127, 21, "Cow",          "İnek",       "The cow is grazing near the fence."),
        (5128, 21, "Chicken",      "Tavuk",      "The chicken laid an egg this morning."),
        (5129, 21, "Rabbit",       "Tavşan",     "A rabbit disappeared into the bushes."),
        (5130, 21, "Bear",         "Ayı",        "The bear searched for food by the river."),
        (5131, 21, "Wolf",         "Kurt",       "A wolf howled somewhere in the forest."),
        (5132, 21, "Lion",         "Aslan",      "The lion rested under a tree."),

        // --- Ders 22: Science ---
        (5133, 22, "Science",      "Bilim",      "Science explains how the world works."),
        (5134, 22, "Research",     "Araştırma",  "Her research took almost three years."),
        (5135, 22, "Experiment",   "Deney",      "The experiment gave a surprising result."),
        (5136, 22, "Theory",       "Kuram",      "This theory is still being tested."),
        (5137, 22, "Energy",       "Enerji",     "The sun gives us energy every day."),
        (5138, 22, "Gravity",      "Yerçekimi",  "Gravity pulls everything towards the ground."),
        (5139, 22, "Cell",         "Hücre",      "Every living thing is made of cells."),
        (5140, 22, "Atom",         "Atom",       "An atom is far too small to see."),
        (5141, 22, "Planet",       "Gezegen",    "Our planet is mostly covered by water."),
        (5142, 22, "Chemistry",    "Kimya",      "She teaches chemistry at the university."),
        (5143, 22, "Biology",      "Biyoloji",   "Biology is the study of living things."),
        (5144, 22, "Evidence",     "Kanıt",      "There is strong evidence for this idea."),

        // --- Ders 23: Film and Cinema ---
        (5145, 23, "Film",         "Film",       "The film lasted almost three hours."),
        (5146, 23, "Cinema",       "Sinema",     "There is a new cinema near the park."),
        (5147, 23, "Actor",        "Oyuncu",     "The actor learned the whole script."),
        (5148, 23, "Director",     "Yönetmen",   "The director shot the scene twice."),
        (5149, 23, "Scene",        "Sahne",      "That scene was filmed in one take."),
        (5150, 23, "Subtitle",     "Altyazı",    "I watch films with subtitles."),
        (5151, 23, "Comedy",       "Komedi",     "We chose a comedy for the evening."),
        (5152, 23, "Drama",        "Dram",       "The drama moved everyone in the room."),
        (5153, 23, "Series",       "Dizi",       "The series has four seasons."),
        (5154, 23, "Episode",      "Bölüm",      "The last episode airs on Sunday."),
        (5155, 23, "Ending",       "Son",        "Nobody expected that ending."),
        (5156, 23, "Character",    "Karakter",   "My favourite character appears late."),

        // --- Ders 24: Gaming ---
        (5157, 24, "Game",         "Oyun",       "The game takes about ten hours."),
        (5158, 24, "Level",        "Seviye",     "He finished the last level yesterday."),
        (5159, 24, "Console",      "Konsol",     "The console is connected to the television."),
        (5160, 24, "Controller",   "Kumanda",    "My controller needs new batteries."),
        (5161, 24, "Mission",      "Görev",      "This mission is harder than the others."),
        (5162, 24, "Reward",       "Ödül",       "You get a reward for finishing early."),
        (5163, 24, "Tournament",   "Turnuva",    "The tournament starts next weekend."),
        (5164, 24, "Achievement",  "Başarım",    "She unlocked every achievement."),
        (5165, 24, "Puzzle",       "Bulmaca",    "The puzzle took me an hour to solve."),
        (5166, 24, "Strategy",     "Strateji",   "A better strategy would save time."),
        (5167, 24, "Opponent",     "Rakip",      "My opponent played very carefully."),
        (5168, 24, "Challenge",    "Meydan okuma", "The final challenge is optional."),
    };

    internal static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>().HasData(Lessons.Select(lesson => new Lesson
        {
            LessonID = lesson.Id,
            Title = lesson.Title,
            Description = lesson.Description,
            Level = lesson.Level,
            OrderIndex = lesson.Order,
            CreatedAt = SeedCreatedAt
        }));

        modelBuilder.Entity<Vocabulary>().HasData(Words.Select(word => new Vocabulary
        {
            WordID = word.WordId,
            DeckId = null,
            CategoryId = LessonCategory[word.LessonId],
            Term = word.Term,
            Translation = word.Translation,
            ExampleSentence = word.Example,
            CreatedAt = SeedCreatedAt
        }));

        modelBuilder.Entity<LessonVocabulary>().HasData(Words.Select(word => new LessonVocabulary
        {
            LessonID = word.LessonId,
            WordID = word.WordId
        }));
    }
}
