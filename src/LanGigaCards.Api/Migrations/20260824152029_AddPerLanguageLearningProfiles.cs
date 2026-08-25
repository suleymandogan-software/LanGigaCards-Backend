using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPerLanguageLearningProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_TargetProficiencyLevel",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories");

            migrationBuilder.DropIndex(
                name: "IX_DailyStudySummaries_UserId_Day",
                table: "DailyStudySummaries");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "UserCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "StudyActivities",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "DailyStudySummaries",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories",
                columns: new[] { "UserId", "CategoryId", "LanguageCode" });

            migrationBuilder.CreateTable(
                name: "UserLanguageProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DifficultyMode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsSetupCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CurrentStreak = table.Column<int>(type: "int", nullable: false),
                    LongestStreak = table.Column<int>(type: "int", nullable: false),
                    TotalXp = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LastStudiedDeckId = table.Column<int>(type: "int", nullable: true),
                    LastStudiedWordId = table.Column<int>(type: "int", nullable: true),
                    LastStudiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguageProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguageProfiles_Decks_LastStudiedDeckId",
                        column: x => x.LastStudiedDeckId,
                        principalTable: "Decks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLanguageProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguageProfiles_Vocabularies_LastStudiedWordId",
                        column: x => x.LastStudiedWordId,
                        principalTable: "Vocabularies",
                        principalColumn: "WordID");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_TargetProficiencyLevel",
                table: "Users",
                sql: "[TargetProficiencyLevel] IN ('Just Starting', 'Beginner', 'Intermediate', 'Advanced', 'Fluent')");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStudySummaries_UserId_Day_LanguageCode",
                table: "DailyStudySummaries",
                columns: new[] { "UserId", "Day", "LanguageCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguageProfiles_LastStudiedDeckId",
                table: "UserLanguageProfiles",
                column: "LastStudiedDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguageProfiles_LastStudiedWordId",
                table: "UserLanguageProfiles",
                column: "LastStudiedWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguageProfiles_UserId_LanguageCode",
                table: "UserLanguageProfiles",
                columns: new[] { "UserId", "LanguageCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLanguageProfiles");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_TargetProficiencyLevel",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories");

            migrationBuilder.DropIndex(
                name: "IX_DailyStudySummaries_UserId_Day_LanguageCode",
                table: "DailyStudySummaries");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "UserCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "StudyActivities");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "DailyStudySummaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories",
                columns: new[] { "UserId", "CategoryId" });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_TargetProficiencyLevel",
                table: "Users",
                sql: "[TargetProficiencyLevel] IN ('Just Starting', 'Beginner', 'Intermediate', 'Advanced')");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStudySummaries_UserId_Day",
                table: "DailyStudySummaries",
                columns: new[] { "UserId", "Day" },
                unique: true);
        }
    }
}
