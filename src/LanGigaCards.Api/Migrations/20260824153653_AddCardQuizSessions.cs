using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCardQuizSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "QuizSessions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "QuizSessionAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizSessionAnswers_WordId",
                table: "QuizSessionAnswers",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSessionAnswers_Vocabularies_WordId",
                table: "QuizSessionAnswers",
                column: "WordId",
                principalTable: "Vocabularies",
                principalColumn: "WordID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizSessionAnswers_Vocabularies_WordId",
                table: "QuizSessionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuizSessionAnswers_WordId",
                table: "QuizSessionAnswers");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "QuizSessions");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "QuizSessionAnswers");
        }
    }
}
