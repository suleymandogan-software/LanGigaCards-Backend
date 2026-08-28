namespace LanGigaCards.Api.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconName { get; set; } = string.Empty;
    public string ColorHex { get; set; } = string.Empty;
}

public class LearningPurposeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class AchievementDto
{
    public int AchievementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string UnlockCondition { get; set; } = string.Empty;
    public int Threshold { get; set; }
    public bool IsSupported { get; set; }
    public string? UnsupportedReason { get; set; }
    public bool IsUnlocked { get; set; }
    public DateTime? UnlockedAt { get; set; }
}

public class NewlyUnlockedAchievementDto
{
    public int AchievementId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class EvaluateAchievementsResponseDto
{
    public List<NewlyUnlockedAchievementDto> NewlyUnlocked { get; set; } = new();
}

public class StatisticsPeriodDto
{
    public DateTime Start { get; set; }
    public DateTime To { get; set; }
}

public class StatisticsOverviewDto
{
    public StatisticsPeriodDto Period { get; set; } = new();
    public int TotalStudySeconds { get; set; }
    public double TotalStudyMinutes { get; set; }
    public double QuizAccuracyPercent { get; set; }
    public int QuizQuestionsAnswered { get; set; }
    public int CorrectAnswers { get; set; }
    public int ReviewCount { get; set; }
    public int CompletedLessons { get; set; }
    public int DueReviews { get; set; }
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public int TotalXp { get; set; }
    public int Level { get; set; }
}

public class HeatmapPointDto
{
    public DateTime Date { get; set; }
    public int StudySeconds { get; set; }
    public int Reviews { get; set; }
    public int QuizAnswers { get; set; }
    public int XpEarned { get; set; }
}

public class DeckSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? CoverImageUrl { get; set; }

    /// <summary>
    /// Uygulamanın oluşturduğu başlangıç destelerinde dolu ("basics_DE"),
    /// kullanıcının kendi destelerinde null. İstemci hedef dil değiştiğinde
    /// hangi desteleri yenileyeceğini buradan anlar.
    /// </summary>
    public string? StarterKey { get; set; }

    /// <summary>Destenin ait olduğu hedef dilin ISO kodu.</summary>
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Deste adının öğrenenin <em>ana dilindeki</em> karşılığı — "Musik" için
    /// "Müzik".
    ///
    /// <para>
    /// <see cref="Title"/> hedef dilde kalır: deste adını okumak öğrenilen
    /// dille ilk temastır ve onu çevirmek o teması yok ederdi. Ama yeni
    /// başlayan biri "Wissenschaft"ın ne olduğunu bilmez, o yüzden istemci ana
    /// dildeki karşılığını yanına küçük puntoyla yazıyor.
    /// </para>
    ///
    /// <para>
    /// Yalnızca şablondan kurulmuş kategori destelerinde dolu; kullanıcının
    /// kendi yazdığı deste adının çevirisi yoktur ve burası null kalır —
    /// istemci de o zaman parantezi hiç göstermez.
    /// </para>
    /// </summary>
    public string? NativeTitle { get; set; }

    /// <summary>
    /// Deste kartındaki emoji ("💻") -- yalnızca şablondan kurulmuş kategori
    /// destelerinde dolu (bkz. <see cref="DeckTemplate.Emoji"/>). Kullanıcının
    /// kendi destesinde ve istemcinin kendi "starter_" destelerinde null:
    /// ikisinin de burada karşılığı yok, istemci kendi varsayılanını kullanır.
    /// </summary>
    public string? Emoji { get; set; }

    /// <summary>Deste kartının vurgu rengi ("#06B6D4"), aynı kaynaktan.</summary>
    public string? ColorHex { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CardCount { get; set; }

    /// <summary>
    /// Süresi geçmiş, gerçekten "gecikmiş" tekrar sayısı — yalnızca daha önce
    /// en az bir kez çalışılmış kartları sayar. Hiç açılmamış bir destenin
    /// kartları burada 0 kalır: henüz hiç görülmemiş bir kart "tekrar zamanı
    /// gelmiş" değildir, bu ikisi ayrı durumlar. Kırmızı "X gecikmiş" rozeti
    /// bu alanı okur.
    /// </summary>
    public int DueCount { get; set; }

    /// <summary>
    /// "Study" düğmesine basılırsa gerçekten kaç kart gelecek --
    /// <c>ProgressController.GetDueReviews</c> ile birebir aynı
    /// kritere göre: hiç çalışılmamış her kart <em>ve</em> süresi geçmiş her
    /// kart. <see cref="DueCount"/>'tan kasıtlı olarak farklı -- deste hiç
    /// açılmamışsa DueCount 0 kalır (henüz "gecikmiş" değil) ama StudyCount
    /// yine de deste kartlarının tamamını sayar (hepsi ilk kez görülecek).
    /// Bir desteyi kısmen çalışıp yarıda bırakınca da bu iki sayı ayrışır:
    /// henüz görülmemiş kartlar DueCount'ta hiç görünmez, oysa bir sonraki
    /// oturum onları da getirir -- StudyCount bunu doğru yansıtır.
    /// </summary>
    public int StudyCount { get; set; }

    public double MasteryPercentage { get; set; }
    public int ReviewsCount { get; set; }
}

public class FlashcardDto
{
    public int WordId { get; set; }
    public int? DeckId { get; set; }
    public string Term { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
    public string? ExampleSentence { get; set; }
    public string? ImageUrl { get; set; }
    public string? AudioUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
