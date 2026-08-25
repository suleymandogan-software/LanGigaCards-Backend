using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.Entities;

public class UserCategory
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    /// <summary>
    /// Seçimin hangi hedef dil için yapıldığı. Bileşik anahtarın parçası: aynı
    /// kategori iki farklı dilde ayrı ayrı seçilebilmeli — Almanca çalışırken
    /// yemek konusunu isteyen biri, Japoncada istemeyebilir.
    ///
    /// Boş dize, alan eklenmeden önce yapılmış seçimleri gösterir; onlar her
    /// dilde geçerli sayılır.
    /// </summary>
    [MaxLength(10)]
    public string LanguageCode { get; set; } = string.Empty;
}
