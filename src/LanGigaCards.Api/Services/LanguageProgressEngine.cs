using Microsoft.EntityFrameworkCore;

namespace LanGigaCards.Api.Services;

/// <summary>
/// Dil bazlı öğrenme durumunu tutan tek yer: profil satırının açılması, o
/// dildeki seri/XP/seviye sayaçları ve "en son çalışılan deste/kelime".
///
/// <para>
/// <see cref="StudyEngine"/> aynı işi hesabın tamamı için yapar ve öyle kalır —
/// rozetler, toplam XP ve hesap ömrü boyunca en uzun seri hâlâ tüm dilleri
/// birlikte sayar. Buradaki sayaçlar tek bir dile aittir; ikisi aynı
/// aktiviteden beslenir ama farklı soruları yanıtlar.
/// </para>
///
/// <para>
/// Her çalışma aktivitesinin yanında <see cref="RecordAsync"/> çağrılır.
/// Çağrılmazsa ham aktivite yine yazılır, yalnızca o dilin özeti geride kalır —
/// aktiviteler durduğu için sonradan yeniden hesaplanabilir.
/// </para>
///
/// <para>
/// Buradaki dil kodları ISO kabul edilir. Bayrak kodundan çevirme
/// (<c>GB</c> -&gt; <c>en</c>) tek geçitte, <see cref="LanguageCodeResolver"/>
/// içinde yapılıyor ve kaynağı <c>Language.FlagCode</c> sütunu; ikinci bir
/// eşleme tablosu zamanla ondan ayrışırdı.
/// </para>
/// </summary>
internal static class LanguageProgressEngine
{
    /// <summary>
    /// Karşılaştırma için tek biçime indirger. Yalnızca kırpma ve küçük harf:
    /// buraya gelen kodlar zaten çözülmüş olmalı.
    /// </summary>
    private static string Normalize(string? code) => (code ?? string.Empty).Trim().ToLowerInvariant();

    /// <summary>
    /// Kullanıcının o dildeki profilini getirir, yoksa oluşturur.
    ///
    /// Yeni satır <see cref="UserLanguageProfile.IsSetupCompleted"/> false ile
    /// açılır: dil ilk kez seçilmiştir ve istemcinin seviye ölçümü ile kategori
    /// seçimini sorması gerekir. Var olan satır asla sıfırlanmaz — öğrenen eski
    /// bir dile geri döndüğünde serisi ve puanı yerindedir.
    /// </summary>
    internal static async Task<UserLanguageProfile?> GetOrCreateAsync(
        IUnitOfWork unitOfWork,
        int userId,
        string? languageCode,
        string? languageName = null,
        string? proficiencyLevel = null)
    {
        var code = await LanguageCodeResolver.ResolveAsync(unitOfWork, languageCode);
        if (code.Length == 0)
        {
            return null;
        }

        var repository = unitOfWork.Repository<UserLanguageProfile>();
        var existing = (await repository.FindAsync(p => p.UserId == userId && p.LanguageCode == code))
            .FirstOrDefault();
        if (existing is not null)
        {
            // Adı boş kalmış eski satırlar (geçiş sırasında dil adı
            // bilinmiyordu) ilk fırsatta doldurulur.
            if (string.IsNullOrWhiteSpace(existing.LanguageName) && !string.IsNullOrWhiteSpace(languageName))
            {
                existing.LanguageName = languageName.Trim();
                repository.Update(existing);
            }

            return existing;
        }

        var created = new UserLanguageProfile
        {
            UserId = userId,
            LanguageCode = code,
            LanguageName = (languageName ?? string.Empty).Trim(),
            ProficiencyLevel = string.IsNullOrWhiteSpace(proficiencyLevel) ? "Beginner" : proficiencyLevel.Trim(),
            DifficultyMode = DifficultyModeFor(proficiencyLevel),
            IsSetupCompleted = false
        };

        await repository.AddAsync(created);
        return created;
    }

    /// <summary>
    /// Onboarding seviyelerini kelime seçiminin kullandığı CEFR tavanına
    /// çevirir. <see cref="CategoryDeckSynchronizer"/> aynı eşleşmeyi kendi
    /// içinde yapıyor; buradaki, yeni bir dil kurulurken tavanın baştan doğru
    /// yazılması için.
    /// </summary>
    internal static string DifficultyModeFor(string? proficiencyLevel) =>
        (proficiencyLevel ?? string.Empty).Trim().ToLowerInvariant() switch
        {
            "just starting" => "A1",
            "beginner" => "A2",
            "intermediate" => "B2",
            "advanced" => "C2",
            "fluent" => "C2",
            _ => "B1",
        };

    /// <summary>
    /// Bir çalışma aktivitesini o dilin profiline işler: XP, seviye, seri ve en
    /// son çalışılan deste/kelime.
    ///
    /// Aktivitenin <see cref="StudyActivity.LanguageCode"/> alanı boşsa hiçbir
    /// şey yapılmaz — hangi dile yazılacağı bilinmeyen bir aktiviteyi rastgele
    /// bir profile eklemektense o dilin özetini eksik bırakmak yeğdir.
    /// </summary>
    internal static Task RecordAsync(IUnitOfWork unitOfWork, StudyActivity activity, string? languageName = null) =>
        RecordManyAsync(unitOfWork, new[] { activity }, languageName);

    /// <summary>
    /// Aynı isteğe ait birden çok aktiviteyi tek geçişte işler.
    ///
    /// Tek tek <see cref="RecordAsync"/> çağırmak burada işe yaramaz: profil
    /// satırı veritabanından okunuyor ve henüz kaydedilmemiş bir satırı
    /// göremiyor — her çağrı aynı dil için bir satır daha eklemeye çalışır ve
    /// benzersizlik kısıtına çarpar. Ayrıca seri hesabı her seferinde tüm
    /// aktivite geçmişini okuyor; beş soruluk bir quiz için beş kez yapılması
    /// gereksiz.
    /// </summary>
    internal static async Task RecordManyAsync(
        IUnitOfWork unitOfWork,
        IReadOnlyList<StudyActivity> activities,
        string? languageName = null)
    {
        foreach (var group in activities.GroupBy(a => Normalize(a.LanguageCode)))
        {
            if (group.Key.Length == 0)
            {
                continue;
            }

            await RecordGroupAsync(unitOfWork, group.Key, group.ToList(), languageName);
        }
    }

    private static async Task RecordGroupAsync(
        IUnitOfWork unitOfWork,
        string code,
        IReadOnlyList<StudyActivity> activities,
        string? languageName)
    {
        var userId = activities[0].UserId;
        var latest = activities.OrderBy(a => a.OccurredAt).Last();

        var profile = await GetOrCreateAsync(unitOfWork, userId, code, languageName);
        if (profile is null)
        {
            return;
        }

        profile.TotalXp = Math.Max(0, profile.TotalXp + activities.Sum(a => a.XpEarned));
        profile.Level = Math.Max(1, profile.TotalXp / StudyEngine.XpPerLevel + 1);

        // Seri, o dildeki aktivite günlerinden hesaplanır. Sorgu aktivite
        // tablosuna gider çünkü profilde gün listesi tutulmuyor.
        var days = await unitOfWork.Repository<StudyActivity>().Query()
            .Where(row => row.UserId == userId && row.LanguageCode == code)
            .Select(row => row.OccurredAt)
            .ToListAsync();

        var dates = days.Concat(activities.Select(a => a.OccurredAt)).ToList();
        profile.CurrentStreak = StudyEngine.CalculateCurrentStreak(dates, latest.OccurredAt);
        profile.LongestStreak = Math.Max(profile.LongestStreak, StudyEngine.CalculateLongestStreak(dates));

        // "En son çalışılan" yalnızca ileri gider: kuyrukta bekleyip geç ulaşan
        // eski bir aktivite, ana ekrandaki kartı geçmişe çekmemeli.
        if (profile.LastStudiedAt is null || latest.OccurredAt >= profile.LastStudiedAt)
        {
            profile.LastStudiedAt = latest.OccurredAt;

            // Deste ve kelime, hepsi arasından en son taşıyandan alınıyor: bir
            // quizin son sorusu deste bilgisi taşımayabilir ama aynı oturumun
            // önceki soruları taşır.
            var lastWithDeck = activities.Where(a => a.DeckId is not null).OrderBy(a => a.OccurredAt).LastOrDefault();
            if (lastWithDeck is not null)
            {
                profile.LastStudiedDeckId = lastWithDeck.DeckId;
            }

            var lastWithWord = activities.Where(a => a.WordId is not null).OrderBy(a => a.OccurredAt).LastOrDefault();
            if (lastWithWord is not null)
            {
                profile.LastStudiedWordId = lastWithWord.WordId;
            }
        }

        // Yeni eklenen satır hâlâ Added durumunda; üzerinde Update çağırmak
        // geçici anahtar yüzünden hata verir.
        if (profile.Id != 0)
        {
            unitOfWork.Repository<UserLanguageProfile>().Update(profile);
        }
    }

    /// <summary>
    /// Bir kartın hangi dile ait olduğunu bulur: kart bir destedeyse destenin
    /// dili, değilse (paylaşılan müfredat kartı) kullanıcının o anki hedef
    /// dili. Deste dili boşsa da aynı geri dönüş uygulanır — dil alanı
    /// eklenmeden önce kurulmuş destelerin kodu yok.
    /// </summary>
    internal static async Task<string> ResolveLanguageAsync(IUnitOfWork unitOfWork, Vocabulary word, User user)
    {
        if (word.DeckId is not null)
        {
            var deck = await unitOfWork.Repository<Deck>().GetByIdAsync(word.DeckId.Value);
            var deckCode = Normalize(deck?.LanguageCode);
            if (deckCode.Length > 0)
            {
                return deckCode;
            }
        }

        return await LanguageCodeResolver.ResolveAsync(unitOfWork, user.TargetLanguageCode);
    }
}
