using System.ComponentModel.DataAnnotations;

namespace LanGigaCards.Api.DTOs;

public class ReportProblemDto
{
    /// <summary>
    /// Üst sınır sütundakiyle aynı (<see cref="Entities.SupportTicket.Message"/>);
    /// burada olması, sınırı aşan metnin veritabanı hatası yerine anlaşılır bir
    /// 400 döndürmesi için.
    /// </summary>
    [Required]
    [MaxLength(4000)]
    public string Message { get; set; } = string.Empty;
}
