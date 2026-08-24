using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFsrsMemoryState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Difficulty",
                table: "UserWordProgresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Stability",
                table: "UserWordProgresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            // Eski zamanlayıcıyla çalışılmış bir kart, bir sonraki tekrarında
            // yepyeni sayılmasın diye tek seferlik doldurma (FsrsEngine,
            // Stability <= 0 olan kaydı "hiç tekrar edilmemiş" kabul ediyor).
            // Bu bir yaklaşıklık — iki model arasında birebir matematiksel
            // karşılık yok — ama makul bir başlangıç: IntervalDays, belleğin
            // tekrarlar arasında ne kadar süre ayakta kaldığının iyi bir
            // göstergesi; EaseFactor (1.3 en zor .. 3.0 en kolay) ise FSRS'in
            // Difficulty ölçeğine (1 en kolay .. 10 en zor) temiz biçimde
            // ters çevriliyor.
            //
            // ReviewCount = 0 olan satırlar gerçekten hiç tekrar edilmemiş;
            // onlar sütun varsayılanında (0) bırakılıyor ve doğru biçimde
            // FsrsEngine'in ilk tekrar yolundan geçiyorlar.
            migrationBuilder.Sql(@"
                UPDATE UserWordProgresses
                SET Stability = CASE WHEN IntervalDays > 0 THEN CAST(IntervalDays AS FLOAT) ELSE 1.0 END,
                    Difficulty = 10.0 - ((EaseFactor - 1.3) / 1.7) * 9.0
                WHERE ReviewCount > 0;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "UserWordProgresses");

            migrationBuilder.DropColumn(
                name: "Stability",
                table: "UserWordProgresses");
        }
    }
}
