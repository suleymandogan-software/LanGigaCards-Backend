using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

/// <summary>
/// Uygulamanın "Yardım ve Destek" ekranından gönderilen sorun bildirimi.
///
/// Henüz bir triyaj/yanıt akışı yok: bu kayıt, "Sorun Bildir" düğmesinin
/// "yakında" mesajı yerine gerçek bir gönderim yapması için var. Bildirimleri
/// şimdilik doğrudan veritabanından okuyoruz.
///
/// Kullanıcı silindiğinde bildirimleri de gider (Cascade): bildirim kimin
/// yazdığından bağımsız olarak saklanacak bir kayıt değil, hesabın parçası.
/// </summary>
public class SupportTicket
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    [MaxLength(4000)]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
