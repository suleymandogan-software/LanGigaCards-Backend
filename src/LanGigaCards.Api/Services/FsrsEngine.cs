namespace LanGigaCards.Api.Services;

/// <summary>Bir kartın tekrardan sonraki bellek durumu.</summary>
public sealed record FsrsReview(double Stability, double Difficulty, DateTime NextReviewDate, int MasteryLevel);

/// <summary>
/// FSRS ("Free Spaced Repetition Scheduler") — <see cref="StudyEngine"/> içinde
/// duran, elle ayarlanmış SM-2 türevi formülün yerine geçer.
///
/// Her kartı iki sayıyla modelliyor: Difficulty (1-10, kelimenin kendiliğinden
/// ne kadar zor olduğu) ve Stability (öngörülen hatırlama olasılığı %90'a
/// düşene kadar geçen gün sayısı). Retrievability ise verilen bir süre sonunda
/// gerçek hatırlama olasılığını Stability'den türetir.
///
/// Formüller ve varsayılan ağırlıklar open-spaced-repetition projesinin
/// yayımlanmış FSRS-6 tanımından ve py-fsrs referans uygulamasından
/// (github.com/open-spaced-repetition/py-fsrs) alındı; Anki de bugün
/// varsayılan olarak bu algoritmayla zamanlıyor. Ağırlıklar milyonlarca gerçek
/// tekrar üzerinde eğitilmiş ve bilerek olduğu gibi kullanılıyor: projenin
/// kendi önerisine göre kullanıcıya özgü optimizasyon, bir öğrenenin birkaç yüz
/// tekrarı birikmeden anlamlı değil ve bu uygulamada hiçbir hesap oraya yakın
/// değil.
///
/// Bilerek uygulanmayan kısım: FSRS-6'nın aynı gün içindeki ikinci tekrar için
/// kullandığı kararlılık formülü (w17-w19). "Again" burada bunun yerine
/// uygulamanın mevcut davranışını koruyor — uzun vadeli aralıktan bağımsız,
/// kısa bir yeniden öğrenme adımı. Anki de kısa vadeli "learning steps"i uzun
/// vadeli zamanlayıcıdan ayrı tutuyor.
/// </summary>
public static class FsrsEngine
{
    // FSRS-6 varsayılan parametreleri (21 ağırlık), py-fsrs'in yayımlanmış
    // varsayılanlarından birebir.
    private static readonly double[] W =
    {
        0.212, 1.2931, 2.3065, 8.2956, 6.4133, 0.8334, 3.0194, 0.001, 1.8722,
        0.1666, 0.796, 1.4835, 0.0614, 0.2629, 1.6483, 0.6014, 1.8729, 0.5425,
        0.0912, 0.0658, 0.1542,
    };

    /// <summary>
    /// Sonraki tekrar zamanlanırken hedeflenen hatırlama olasılığı — py-fsrs
    /// varsayılanının aynısı. Yükseltmek daha sık ve daha kısa aralıklı tekrar,
    /// daha az unutma toleransı demek.
    ///
    /// Şu an kullanıcıya özgü bir tercihe bağlı değil (istemcinin eski
    /// Easy/Adaptive/Hard "Difficulty Mode" ayarı CEFR seviyesi seçicisine
    /// dönüştü, bkz. <see cref="ProficiencyDifficultyOffsetFor"/>), ama satır
    /// içine gömmek yerine parametre olarak duruyor: gerçek bir kullanıcı
    /// tercihi geldiğinde bu metodun şeklini yeniden değiştirmek gerekmesin.
    /// </summary>
    public const double DefaultRequestRetention = 0.90;

    /// <summary>
    /// Öğrenenin kendi bildirdiği CEFR seviyesinden gelen, yalnızca ilk tekrara
    /// uygulanan küçük başlangıç zorluğu düzeltmesi (istemcideki
    /// <c>DifficultyMode</c> seçicisi, A1..C2 — bkz.
    /// <c>UserSettings.DifficultyMode</c>). Sıfırdan başlayan biri (A1) yeni bir
    /// kelimeyi verdiği nottan biraz daha zor kabul edecek yöne, akıcılığa yakın
    /// biri (C2) ters yöne itiliyor. Bu yalnızca kelimenin <em>ilk</em> tekrarına
    /// dokunur; sonraki her tekrar tamamen öğrenenin o kelimedeki gerçek
    /// performansından türer. B1 (alanın kendi varsayılanı) bilerek sıfır
    /// düzeltme uygular, böylece bu ayara hiç dokunmamış bir hesabın davranışı
    /// değişmez.
    ///
    /// Değerler kasten dar tutuldu: Medium için başlangıç zorluğu ~2.12, Easy
    /// için zaten 1.0 tabanına kırpılıyor. Daha geniş bir yelpaze, her seviyede
    /// ilk notların çoğunu doğrudan tabana bastırır ve tam da ayırmaya
    /// çalıştığımız farkı yok ederdi.
    /// </summary>
    public static double ProficiencyDifficultyOffsetFor(string? cefrLevel) => cefrLevel?.Trim().ToUpperInvariant() switch
    {
        "A1" => 0.75,
        "A2" => 0.5,
        "B1" => 0,
        "B1+" => -0.15,
        "B2" => -0.35,
        "C1" => -0.6,
        "C2" => -0.85,
        _ => 0,
    };

    private const double MinStability = 0.1;

    /// <summary>
    /// 0=Again, 1=Hard, 2=Medium ("Good"), 3=Easy — uygulamanın kendi dört notu,
    /// FSRS'in kendi not sırasıyla.
    /// </summary>
    private static int GradeIndex(string rating) => rating switch
    {
        "Again" => 0,
        "Hard" => 1,
        "Medium" => 2,
        "Easy" => 3,
        _ => throw new ArgumentOutOfRangeException(nameof(rating), "Unsupported review rating."),
    };

    /// <summary>
    /// Verilen kararlılıkta, üzerinden [daysElapsed] gün geçtikten sonraki
    /// hatırlama olasılığı. Hiç tekrar edilmemiş kart için 0.
    /// </summary>
    public static double Retrievability(double stability, double daysElapsed)
    {
        if (stability <= 0)
        {
            return 0;
        }

        var w20 = W[20];
        var factor = Math.Pow(0.9, -1.0 / w20) - 1.0;
        return Math.Pow(1 + factor * daysElapsed / stability, -w20);
    }

    /// <summary>
    /// Verilen kararlılıktaki bir kartta, öngörülen hatırlama olasılığının
    /// [requestRetention] değerine düşmesi için geçmesi gereken gün sayısı.
    /// </summary>
    public static double IntervalForRetention(double stability, double requestRetention)
    {
        var w20 = W[20];
        var factor = Math.Pow(0.9, -1.0 / w20) - 1.0;
        return (stability / factor) * (Math.Pow(requestRetention, -1.0 / w20) - 1.0);
    }

    /// <summary>
    /// Tekrardan sonraki yeni bellek durumunu ve bir sonraki tekrar tarihini
    /// hesaplar. [currentStability] sıfır ya da altındaysa kart "hiç tekrar
    /// edilmemiş" sayılır — eski EaseFactor/ReviewCount değerleri ne olursa
    /// olsun, bu kartın ilk tekrarıdır.
    /// </summary>
    public static FsrsReview ReviewCard(
        double currentStability,
        double currentDifficulty,
        DateTime? lastReviewedAt,
        string rating,
        DateTime reviewedAt,
        double requestRetention = DefaultRequestRetention,
        string? cefrLevel = null)
    {
        var g = GradeIndex(rating);
        var isFirstReview = currentStability <= 0;

        double stability;
        double difficulty;

        if (isFirstReview)
        {
            stability = Math.Max(W[g], MinStability);
            difficulty = Math.Clamp(InitialDifficulty(g) + ProficiencyDifficultyOffsetFor(cefrLevel), 1, 10);
        }
        else
        {
            var elapsedDays = lastReviewedAt is null ? 0 : Math.Max(0, (reviewedAt - lastReviewedAt.Value).TotalDays);
            var retrievability = Retrievability(currentStability, elapsedDays);

            difficulty = NextDifficulty(currentDifficulty, g);
            stability = g == 0
                ? NextForgetStability(difficulty, currentStability, retrievability)
                : NextRecallStability(difficulty, currentStability, retrievability, g);
        }

        stability = Math.Max(stability, MinStability);
        var intervalDays = Math.Max(1, (int)Math.Round(IntervalForRetention(stability, requestRetention)));

        var nextReviewDate = g == 0
            ? reviewedAt.AddMinutes(10)
            : reviewedAt.AddDays(intervalDays);

        return new FsrsReview(stability, difficulty, nextReviewDate, MasteryLevelFrom(stability));
    }

    private static double InitialDifficulty(int g) => Math.Clamp(W[4] - Math.Exp(g * W[5]) + 1, 1, 10);

    private static double NextDifficulty(double difficulty, int g)
    {
        // g sıfırdan başlıyor (Again=0..Easy=3); FSRS kendi "(G-3)" terimini
        // birden başlayan not numarasıyla (Again=1..Easy=4) yazıyor, yani
        // buradaki g-2 aynı terim.
        var deltaD = -W[6] * (g - 2);
        var dampened = deltaD * (10 - difficulty) / 9;
        var reverted = W[7] * InitialDifficulty(3) + (1 - W[7]) * (difficulty + dampened);
        return Math.Clamp(reverted, 1, 10);
    }

    private static double NextRecallStability(double difficulty, double stability, double retrievability, int g)
    {
        var hardPenalty = g == 1 ? W[15] : 1.0;
        var easyBonus = g == 3 ? W[16] : 1.0;
        var factor = Math.Exp(W[8])
            * (11 - difficulty)
            * Math.Pow(stability, -W[9])
            * (Math.Exp(W[10] * (1 - retrievability)) - 1)
            * hardPenalty
            * easyBonus;
        return stability * (factor + 1);
    }

    private static double NextForgetStability(double difficulty, double stability, double retrievability) =>
        W[11] * Math.Pow(difficulty, -W[12]) * (Math.Pow(stability + 1, W[13]) - 1) * Math.Exp(W[14] * (1 - retrievability));

    /// <summary>
    /// FSRS kararlılığını uygulamanın mevcut 0-5 MasteryLevel ölçeğine eşler,
    /// böylece ona bağlı her şey (başarımlar, istatistikler, istemcideki
    /// <c>deriveMemoryStrength</c>) aynı sözleşmeyle çalışmaya devam eder.
    /// Kararlılık gün cinsinden ve eski "tekrar başına +1/-1/+2" sayacıyla aynı
    /// birim değil; bu yüzden eski delta mantığını taşımak yerine kararlılık
    /// eşiklerine göre kovalanıyor: aylardır kararlı duran bir bellek, oraya kaç
    /// tekrarda geldiğinden bağımsız olarak "ustalaşmış" sayılır.
    /// </summary>
    private static int MasteryLevelFrom(double stability)
    {
        if (stability < 1) return 0;
        if (stability < 3) return 1;
        if (stability < 10) return 2;
        if (stability < 30) return 3;
        if (stability < 90) return 4;
        return 5;
    }
}
