using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// ASP.NET Core'un <c>IPasswordHasher</c>'ının ürettiği kodlanmış hash:
    /// sürüm baytı, tuz, tur sayısı ve türetilmiş anahtar tek bir base64
    /// dizede. Ayrı bir tuz sütunu yok, tuz bu değerin içinde.
    ///
    /// Sosyal girişle açılan hesaplarda boş kalır; parola doğrulaması o
    /// hesaplar için hiç çalıştırılmaz.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>Profil görseli URL; yoksa UI initials kullanır.</summary>
    public string? AvatarUrl { get; set; }

    public string NativeLanguage { get; set; } = "English";
    public string TargetLanguage { get; set; } = "Turkish";

    /// <summary>ISO 639-1 language code for TTS / client matching (e.g. en, tr).</summary>
    [MaxLength(8)]
    public string NativeLanguageCode { get; set; } = "en";

    /// <summary>ISO 639-1 language code for TTS / client matching (e.g. en, tr).</summary>
    [MaxLength(8)]
    public string TargetLanguageCode { get; set; } = "tr";

    /// <summary>Figma: Intermediate / Beginner / Advanced vb.</summary>
    public string TargetProficiencyLevel { get; set; } = "Beginner";

    public int DailyGoalMinutes { get; set; } = 10;
    public int CurrentStreak { get; set; } = 0;
    public int LongestStreak { get; set; } = 0;
    public int Level { get; set; } = 1;
    public int TotalXp { get; set; } = 0;

    /// <summary>Figma: Upgrade to Premium / PRO</summary>
    public bool IsPremium { get; set; }

    public string? GoogleId { get; set; }
    public string? AppleId { get; set; }

    /// <summary>
    /// E-posta adresinin doğrulanıp doğrulanmadığı. Bilinçli olarak giriş için
    /// zorunlu tutulmaz — aksi halde bu alan eklenmeden önce kayıt olmuş
    /// kullanıcılar bir anda dışarıda kalırdı. Şimdilik bir durum bilgisidir.
    /// </summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>
    /// Hesap silindi mi.
    ///
    /// Silme isteği satırı kaldırmaz, yalnızca işaretler: desteler, kartlar,
    /// ilerleme ve çalışma geçmişi veritabanında olduğu gibi kalır. İki nedeni
    /// var. Birincisi, bu verilerin çoğu tek bir hesaba ait değil — çalışma
    /// aktiviteleri toplu istatistiklerin, kelime ilerlemesi de müfredat
    /// ölçümlerinin girdisi; satırın gitmesi geçmişi geriye dönük
    /// değiştirirdi. İkincisi, yanlışlıkla silinen bir hesabın geri
    /// getirilebilmesi.
    ///
    /// İşaretli hesap her yerde yok sayılır: <see cref="Data.AppDbContext"/>
    /// üzerindeki genel sorgu süzgeci bu satırları hiçbir sorguya sokmaz, yani
    /// giriş yapılamaz ve elde kalmış bir erişim anahtarı da işe yaramaz —
    /// kullanıcıyı kimliğinden okuyan her yol null görür.
    /// </summary>
    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Bu hesabın açık oturumları — cihaz başına bir satır. Eskiden
    /// <c>User</c> üzerinde tek bir token sütunu vardı, bu yüzden ikinci
    /// cihazdan giriş birincinin oturumunu düşürüyordu. Bkz.
    /// <see cref="Entities.RefreshToken"/>.
    /// </summary>
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public UserSettings? Settings { get; set; }
    /// <summary>
    /// Öğrenilen her hedef dil için bir satır. Yukarıdaki seri, XP ve seviye
    /// hesabın tamamına ait toplamlardır; dil bazındaki karşılıkları
    /// <see cref="UserLanguageProfile"/> içindedir.
    /// </summary>
    public ICollection<UserLanguageProfile> LanguageProfiles { get; set; } = new List<UserLanguageProfile>();

    public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
    public ICollection<UserLearningPurpose> UserLearningPurposes { get; set; } = new List<UserLearningPurpose>();
    public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
    public ICollection<Deck> Decks { get; set; } = new List<Deck>();
    public ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
    public ICollection<UserWordProgress> UserWordProgresses { get; set; } = new List<UserWordProgress>();
    public ICollection<StudyActivity> StudyActivities { get; set; } = new List<StudyActivity>();
    public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = new List<PasswordResetToken>();
    public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = new List<EmailVerificationToken>();
    public ICollection<QuizSession> QuizSessions { get; set; } = new List<QuizSession>();
}
