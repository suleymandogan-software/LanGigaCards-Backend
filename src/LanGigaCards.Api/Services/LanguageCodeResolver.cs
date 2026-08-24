using Microsoft.EntityFrameworkCore;

namespace LanGigaCards.Api.Services;

/// <summary>
/// Kullanıcının profilinde duran dil kodunu, içeriğin anahtarlandığı ISO koduna
/// çevirir.
///
/// İstemcinin dil seçicisi ISO 639-1 değil, bayrak/ülke kodu gönderiyor
/// (<c>MockData.languages</c>: İngilizce için <c>GB</c>, Japonca <c>JP</c>,
/// Korece <c>KR</c>, Çince <c>CN</c>). Tam da bu dördü ISO karşılığıyla
/// çakışmayanlar; <c>DE</c>/<c>FR</c>/<c>ES</c>/<c>IT</c>/<c>PT</c>/<c>TR</c>
/// küçük harfe indiğinde kendi ISO koduna denk geldiği için sorun uzun süre
/// görünmedi.
///
/// Çevrilmediğinde <c>gb</c>/<c>jp</c>/<c>kr</c>/<c>cn</c> hiçbir
/// <see cref="ConceptTranslation.LanguageCode"/> ile eşleşmiyor: o dilleri
/// çalışan kullanıcıya kavram oturumu boş dönüyor, tekrar gönderimi ise 404
/// alıyordu — yani içerik var ama kullanıcıya hiç ulaşmıyordu.
///
/// Eşleme sabit bir tablo olarak değil <see cref="Language"/> katalogundan
/// okunuyor: <c>Code</c> ve <c>FlagCode</c> zaten orada duruyor
/// (<c>CatalogSeedData</c>), ikinci bir kopya zamanla ondan ayrışırdı.
/// </summary>
internal static class LanguageCodeResolver
{
    /// <summary>
    /// Tanınmayan kod olduğu gibi (küçük harfe indirilmiş) geri döner: dil
    /// katalogu büyüdüğünde burada bilinmeyen bir kodu boşa çevirmek, çalışan
    /// bir dili sessizce kapatmak olurdu.
    /// </summary>
    public static async Task<string> ResolveAsync(IUnitOfWork unitOfWork, string? code)
    {
        var normalized = (code ?? string.Empty).Trim().ToLowerInvariant();
        if (normalized.Length == 0)
        {
            return string.Empty;
        }

        // Doğrudan ISO eşleşmesi önce: hiçbir bayrak kodu başka bir dilin ISO
        // koduyla çakışmıyor, ama sıralamayı belirtmek bu varsayımı ileride
        // yeni bir dil bozarsa sonucun rastgele değişmesini engelliyor.
        var match = await unitOfWork.Repository<Language>().Query()
            .Where(language => language.Code == normalized || language.FlagCode == normalized)
            .OrderBy(language => language.Code == normalized ? 0 : 1)
            .Select(language => language.Code)
            .FirstOrDefaultAsync();

        return match ?? normalized;
    }
}
