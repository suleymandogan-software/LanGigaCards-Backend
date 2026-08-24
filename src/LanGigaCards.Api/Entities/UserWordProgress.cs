using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Kullanıcıya özel SRS ilerlemesi. Aynı kart birden fazla kullanıcıda
/// farklı durum tutabilir.
///
/// Bir satır ya öğrencinin kendi destesindeki bir karta
/// (<see cref="WordID"/>) ya da paylaşılan müfredattaki bir kavrama
/// (<see cref="ConceptId"/> + <see cref="LanguageCode"/>) aittir; ikisi
/// birden dolu olamaz, ikisi birden boş da olamaz. Bu kural veritabanında
/// bir CHECK kısıtıyla da tekrarlanıyor.
///
/// İkisini ayrı tablolara bölmek yerine tek tabloda tutmanın nedeni SM-2
/// hesabının tek olması: aralık, kolaylık katsayısı ve ustalık her iki
/// durumda da aynı şekilde işliyor, ayrı tablo aynı kodu ikinci kez
/// yazmayı gerektirirdi.
/// </summary>
public class UserWordProgress
{
    [Key]
    public long UserWordID { get; set; }

    public int UserID { get; set; }
    public User User { get; set; } = null!;

    /// <summary>Öğrencinin kendi destesindeki kart. Müfredat satırlarında null.</summary>
    public int? WordID { get; set; }
    public Vocabulary? Vocabulary { get; set; }

    /// <summary>Müfredattaki kavram. Kendi kartlarında null.</summary>
    public int? ConceptId { get; set; }
    public Concept? Concept { get; set; }

    /// <summary>
    /// Kavramın hangi dilde çalışıldığı. İlerlemenin parçası, çünkü aynı
    /// kavramı Almanca ve İspanyolca öğrenmek iki ayrı iştir — hedef dilini
    /// değiştiren biri sıfırdan başlamalı, bittiği yerden değil.
    /// </summary>
    public string? LanguageCode { get; set; }

    public int MasteryLevel { get; set; } = 0;
    public DateTime? NextReviewDate { get; set; }
    public DateTime LastReviewedAt { get; set; } = DateTime.UtcNow;

    public int ReviewCount { get; set; }

    /// <summary>
    /// Eski SM-2 türevi alanlar. Artık tekrar gönderimi tarafından
    /// hesaplanmıyor (yerlerini Stability/Difficulty aldı, bkz.
    /// <see cref="Services.FsrsEngine"/>); yalnızca mevcut satırlar ve bu
    /// tabloyu dışarıdan okuyan biri bir sütunun kaybolmasıyla bozulmasın diye
    /// duruyorlar. <see cref="IntervalDays"/> süreklilik için FSRS'in
    /// hesapladığı aralıkla tazeleniyor, <see cref="EaseFactor"/> ise bundan
    /// sonra son SM-2 değerinde donmuş kalıyor.
    /// </summary>
    public double EaseFactor { get; set; } = 2.5;
    public int IntervalDays { get; set; } = 0;

    /// <summary>
    /// FSRS bellek durumu (bkz. <see cref="Services.FsrsEngine"/>). Sıfır,
    /// "FSRS altında hiç tekrar edilmedi" demek: ya gerçekten yeni bir kelime,
    /// ya da bu migration'dan önce var olan satırlarda eski
    /// EaseFactor/IntervalDays değerlerinden tek seferlik yaklaşık olarak
    /// doldurulmuş bir kayıt.
    /// </summary>
    public double Stability { get; set; } = 0;
    public double Difficulty { get; set; } = 0;

    /// <summary>Son değerlendirme: Again, Hard, Medium, Easy (Figma SRS).</summary>
    public string? LastRating { get; set; }
}
