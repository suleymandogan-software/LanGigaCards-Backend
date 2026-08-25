using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReplacePasswordHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            // Scaffold bunu AlterColumn olarak üretmişti; elle drop + add'e
            // çevrildi. İki nedenle:
            //
            // 1. SQL Server varbinary(max) -> nvarchar(256) dönüşümünü örtük
            //    yapmaz; ALTER COLUMN hata verir.
            // 2. Dönüşse bile sonucu anlamsız olurdu. Eski değer tek turluk
            //    HMACSHA512 çıktısı ve ayrı bir tuz sütununa bağlıydı; tuz
            //    yukarıda düşüyor. Yeni doğrulayıcı bu baytları zaten
            //    okuyamaz, dolayısıyla taşınacak bir veri yok.
            //
            // Sonuç: parolayla açılmış hesaplar giriş yapamaz, "şifremi
            // unuttum" ile yeni parola belirlemeleri gerekir. Sosyal girişle
            // açılan hesaplar zaten boş hash tutuyordu, onlar etkilenmez.
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Up'takiyle simetrik: geri alma da sütunu yeniden oluşturur.
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
