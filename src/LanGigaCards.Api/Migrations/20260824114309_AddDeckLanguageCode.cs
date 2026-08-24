using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDeckLanguageCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "Decks",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            // Sütun eklenmeden önce kurulmuş desteler için doldurma.
            //
            // 1) StarterKey ("category_food_de", "starter_basics_DE") her zaman
            //    destenin gerçek dil koduyla bitiyor; önce ona güveniyoruz.
            migrationBuilder.Sql(@"
                UPDATE Decks
                SET LanguageCode = LOWER(RIGHT(StarterKey, CHARINDEX('_', REVERSE(StarterKey)) - 1))
                WHERE StarterKey IS NOT NULL AND CHARINDEX('_', REVERSE(StarterKey)) > 0;
            ");

            // 2) İstemci bayrak kodu gönderiyor (İngilizce için GB, Japonca JP,
            //    Korece KR, Çince CN), katalog ise ISO ile anahtarlı; birinci
            //    adımın StarterKey'den okuduğu kod da bu biçimde olabilir.
            //    LanguageCodeResolver'ın yaptığı çeviri burada SQL olarak
            //    tekrarlanıyor, çünkü bir migration C# çağıramaz.
            migrationBuilder.Sql(@"
                UPDATE Decks
                SET LanguageCode = CASE LanguageCode
                    WHEN 'gb' THEN 'en'
                    WHEN 'jp' THEN 'ja'
                    WHEN 'kr' THEN 'ko'
                    WHEN 'cn' THEN 'zh'
                    ELSE LanguageCode
                END
                WHERE LanguageCode IS NOT NULL;
            ");

            // 3) Hâlâ boş kalanlar öğrenenin kendi kurduğu desteler; onların
            //    hiç StarterKey'i olmadı. Sahibinin o anki hedef diline
            //    düşülüyor — kendi destesini çoğunlukla çalıştığı dilde kurmuş
            //    olacak.
            //
            //    Bu adımdan sonra da boş kalan satırlar (hedef dili hiç
            //    seçilmemiş hesaplar) bilerek NULL bırakılıyor: DeckController
            //    bunları her dilde gösteriyor, yani yanlış bir dile damgalanıp
            //    öğrenenin gözünden kaybolmaktansa görünür kalıyorlar.
            migrationBuilder.Sql(@"
                UPDATE d
                SET d.LanguageCode = CASE LOWER(u.TargetLanguageCode)
                    WHEN 'gb' THEN 'en'
                    WHEN 'jp' THEN 'ja'
                    WHEN 'kr' THEN 'ko'
                    WHEN 'cn' THEN 'zh'
                    ELSE LOWER(u.TargetLanguageCode)
                END
                FROM Decks d
                JOIN Users u ON u.Id = d.UserId
                WHERE d.LanguageCode IS NULL
                  AND NULLIF(LTRIM(RTRIM(u.TargetLanguageCode)), '') IS NOT NULL;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "Decks");
        }
    }
}
