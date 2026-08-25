namespace LanGigaCards.Api.Services;

/// <summary>
/// Ham çalışma aktivitesini günlük özete işler.
///
/// Her aktivite iki yere yazılır: ayrıntının durduğu <see cref="StudyActivity"/>
/// ve gün başına tek satır tutan <see cref="DailyStudySummary"/>. İkincisi
/// türetilmiş veridir — istatistik ekranının bir yıllık ham aktiviteyi taramak
/// zorunda kalmaması için var.
///
/// Bir aktivite kaydedilirken bu çağrılmazsa özet o gün için eksik kalır; ham
/// veri yerinde durduğu için sonuçlar yeniden hesaplanabilir, ama ekran o güne
/// kadar yanlış gösterir. Bu yüzden çağrı, aktivitenin eklendiği yerin hemen
/// yanında durur.
/// </summary>
internal static class DailySummaryEngine
{
    internal static Task RecordAsync(IUnitOfWork unitOfWork, StudyActivity activity) =>
        RecordManyAsync(unitOfWork, new[] { activity });

    /// <summary>
    /// Aynı isteğe ait birden çok aktiviteyi tek geçişte işler.
    ///
    /// Tek tek <see cref="RecordAsync"/> çağırmak burada işe yaramaz: özet
    /// satırı veritabanından okunuyor ve henüz kaydedilmemiş bir satırı
    /// göremiyor — ikinci aktivite aynı gün için bir satır daha eklemeye
    /// çalışır ve benzersizlik kısıtına çarpar. Beş soruluk bir kart quizi tam
    /// olarak bunu yapıyordu.
    /// </summary>
    internal static async Task RecordManyAsync(IUnitOfWork unitOfWork, IReadOnlyList<StudyActivity> activities)
    {
        foreach (var group in activities.GroupBy(a => (
            Day: DateOnly.FromDateTime(a.OccurredAt),
            Language: (a.LanguageCode ?? string.Empty).Trim().ToLowerInvariant())))
        {
            await RecordGroupAsync(unitOfWork, group.Key.Day, group.Key.Language, group.ToList());
        }
    }

    private static async Task RecordGroupAsync(
        IUnitOfWork unitOfWork,
        DateOnly day,
        string languageCode,
        IReadOnlyList<StudyActivity> activities)
    {
        var first = activities[0];
        var repository = unitOfWork.Repository<DailyStudySummary>();

        // Özet dil başına tutuluyor: bir günün iki dilde ayrı satırı olur.
        // Arama da dili içermek zorunda, yoksa Almanca çalışılan gün Japonca
        // satırının üzerine yazılırdı.
        var summary = (await repository.FindAsync(s => s.UserId == first.UserId
                && s.Day == day
                && s.LanguageCode == languageCode))
            .FirstOrDefault();

        var isNewRow = summary is null;
        if (summary is null)
        {
            summary = new DailyStudySummary
            {
                UserId = first.UserId,
                Day = day,
                LanguageCode = languageCode
            };
            await repository.AddAsync(summary);
        }

        foreach (var activity in activities)
        {
            switch (activity.ActivityType)
            {
                case "Review":
                    summary.ReviewCount++;
                    // "Again" tekrar görülmesi gereken kart demek; isabet
                    // sayısına girmemeli. Diğer üç değerlendirme
                    // (Hard/Medium/Easy) hatırlandı anlamına gelir.
                    if (activity.Result is not null && activity.Result != "Again")
                    {
                        summary.CorrectCount++;
                    }
                    break;

                case "Quiz":
                    summary.QuizCount++;
                    break;

                case "Lesson":
                    summary.LessonCount++;
                    break;
            }

            summary.StudySeconds += activity.DurationSeconds;
            summary.XpEarned += activity.XpEarned;
        }

        summary.UpdatedAt = DateTime.UtcNow;

        // Yalnızca var olan satırda. Yeni eklenen satır hâlâ Added durumunda ve
        // anahtarı geçici; EF üzerinde Update çağrılırsa "temporary value while
        // attempting to change the entity's state to 'Modified'" hatası verir.
        // Zaten gerek de yok — Added varlığın alanlarındaki değişiklikler
        // SaveChanges'te INSERT'e girer.
        if (!isNewRow)
        {
            repository.Update(summary);
        }
    }
}
