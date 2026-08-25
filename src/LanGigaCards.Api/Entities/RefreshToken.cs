namespace LanGigaCards.Api.Entities;

/// <summary>
/// Bir cihazın oturumunu uzatan uzun ömürlü token.
///
/// Önceden bu bilgi <c>Users</c> tablosunda tek bir sütun çiftiydi
/// (<c>RefreshToken</c> / <c>RefreshTokenExpiryTime</c>). İki sorunu vardı:
///
/// Tek yuva. Aynı hesapla ikinci bir cihazdan giriş yapmak birincinin
/// token'ının üzerine yazıyordu; ilk cihaz, kullanıcı hiçbir şey yapmadan,
/// erişim token'ının ömrü dolduğu anda sessizce dışarı atılıyordu.
///
/// Düz metin. Token parolaya eşdeğer bir sırdır — onu taşıyan, ömrü boyunca
/// yeni erişim token'ı alabilir. Veritabanı okuması sızarsa hepsi doğrudan
/// kullanılabilir hale gelirdi. Burada yalnızca SHA-256 özeti saklanıyor;
/// parola hash'inin aksine iş faktörü gerekmiyor, çünkü token 64 rastgele
/// bayt, tahmin edilebilir bir parola değil.
/// </summary>
public class RefreshToken
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    /// <summary>Token'ın SHA-256 özetinin base64'ü. Token'ın kendisi yalnızca istemcide.</summary>
    public string TokenHash { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Yenilendiğinde ya da çıkış yapıldığında doldurulur. Satır silinmiyor:
    /// kullanılmış bir token'ın yeniden sunulması, token'ın çalındığına dair
    /// bir işarettir ve bunu görebilmek için kaydın durması gerekir.
    /// </summary>
    public DateTime? RevokedAt { get; set; }

    public bool IsActive(DateTime now) => RevokedAt is null && ExpiresAt > now;
}
