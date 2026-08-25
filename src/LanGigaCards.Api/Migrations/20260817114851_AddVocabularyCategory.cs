using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddVocabularyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Vocabularies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonID", "CreatedAt", "Description", "Level", "OrderIndex", "Title" },
                values: new object[,]
                {
                    { 21, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pets, farm animals and wildlife", "A2", 21, "Animals" },
                    { 22, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Research, nature's rules and the lab", "B1", 22, "Science" },
                    { 23, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Watching, describing and discussing film", "B1", 23, "Film and Cinema" },
                    { 24, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Playing, competing and progressing", "B1", 24, "Gaming" }
                });

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1001,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1002,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1003,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1004,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1005,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1006,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1007,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1008,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1009,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1010,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1011,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1012,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1013,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1014,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1015,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1016,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1017,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1018,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1019,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1020,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1021,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1022,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1023,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1024,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1025,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1026,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1027,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1028,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1029,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1030,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1031,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1032,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1033,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1034,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1035,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1036,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1037,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1038,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1039,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1040,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1041,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1042,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1043,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1044,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1045,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1046,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1047,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1048,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1049,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1050,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1051,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1052,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1053,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1054,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1055,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1056,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1057,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1058,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1059,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1060,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1061,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1062,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1063,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1064,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1065,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1066,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1067,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1068,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1069,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1070,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1071,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1072,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1073,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1074,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1075,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1076,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1077,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1078,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1079,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1080,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1081,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1082,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1083,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1084,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1085,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1086,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1087,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1088,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1089,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1090,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1091,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1092,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1093,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1094,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1095,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1096,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1097,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1098,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1099,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1100,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1101,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1102,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1103,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1104,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1105,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1106,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1107,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1108,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1109,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1110,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1111,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1112,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1113,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1114,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1115,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1116,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1117,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 1118,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5001,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5002,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5003,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5004,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5005,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5006,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5007,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5008,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5009,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5010,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5011,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5012,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5013,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5014,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5015,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5016,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5017,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5018,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5019,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5020,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5021,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5022,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5023,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5024,
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5025,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5026,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5027,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5028,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5029,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5030,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5031,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5032,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5033,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5034,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5035,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5036,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5037,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5038,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5039,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5040,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5041,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5042,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5043,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5044,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5045,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5046,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5047,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5048,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5049,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5050,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5051,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5052,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5053,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5054,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5055,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5056,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5057,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5058,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5059,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5060,
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5061,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5062,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5063,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5064,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5065,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5066,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5067,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5068,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5069,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5070,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5071,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5072,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5073,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5074,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5075,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5076,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5077,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5078,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5079,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5080,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5081,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5082,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5083,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5084,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5085,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5086,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5087,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5088,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5089,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5090,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5091,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5092,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5093,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5094,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5095,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5096,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5097,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5098,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5099,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5100,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5101,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5102,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5103,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5104,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5105,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5106,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5107,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5108,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5109,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5110,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5111,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5112,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5113,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5114,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5115,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5116,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5117,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5118,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5119,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5120,
                column: "CategoryId",
                value: 5);

            migrationBuilder.InsertData(
                table: "Vocabularies",
                columns: new[] { "WordID", "AudioUrl", "CategoryId", "CreatedAt", "DeckId", "ExampleSentence", "ImageUrl", "Term", "Translation", "UpdatedAt" },
                values: new object[,]
                {
                    { 5121, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The dog waited by the door.", null, "Dog", "Köpek", null },
                    { 5122, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Their cat sleeps all afternoon.", null, "Cat", "Kedi", null },
                    { 5123, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A bird built its nest in the tree.", null, "Bird", "Kuş", null },
                    { 5124, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "We caught three fish in the lake.", null, "Fish", "Balık", null },
                    { 5125, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The horse ran across the field.", null, "Horse", "At", null },
                    { 5126, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The sheep stayed close together.", null, "Sheep", "Koyun", null },
                    { 5127, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The cow is grazing near the fence.", null, "Cow", "İnek", null },
                    { 5128, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The chicken laid an egg this morning.", null, "Chicken", "Tavuk", null },
                    { 5129, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A rabbit disappeared into the bushes.", null, "Rabbit", "Tavşan", null },
                    { 5130, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The bear searched for food by the river.", null, "Bear", "Ayı", null },
                    { 5131, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A wolf howled somewhere in the forest.", null, "Wolf", "Kurt", null },
                    { 5132, null, 15, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The lion rested under a tree.", null, "Lion", "Aslan", null },
                    { 5133, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Science explains how the world works.", null, "Science", "Bilim", null },
                    { 5134, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Her research took almost three years.", null, "Research", "Araştırma", null },
                    { 5135, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The experiment gave a surprising result.", null, "Experiment", "Deney", null },
                    { 5136, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "This theory is still being tested.", null, "Theory", "Kuram", null },
                    { 5137, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The sun gives us energy every day.", null, "Energy", "Enerji", null },
                    { 5138, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Gravity pulls everything towards the ground.", null, "Gravity", "Yerçekimi", null },
                    { 5139, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Every living thing is made of cells.", null, "Cell", "Hücre", null },
                    { 5140, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "An atom is far too small to see.", null, "Atom", "Atom", null },
                    { 5141, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Our planet is mostly covered by water.", null, "Planet", "Gezegen", null },
                    { 5142, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "She teaches chemistry at the university.", null, "Chemistry", "Kimya", null },
                    { 5143, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Biology is the study of living things.", null, "Biology", "Biyoloji", null },
                    { 5144, null, 14, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "There is strong evidence for this idea.", null, "Evidence", "Kanıt", null },
                    { 5145, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The film lasted almost three hours.", null, "Film", "Film", null },
                    { 5146, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "There is a new cinema near the park.", null, "Cinema", "Sinema", null },
                    { 5147, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The actor learned the whole script.", null, "Actor", "Oyuncu", null },
                    { 5148, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The director shot the scene twice.", null, "Director", "Yönetmen", null },
                    { 5149, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "That scene was filmed in one take.", null, "Scene", "Sahne", null },
                    { 5150, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "I watch films with subtitles.", null, "Subtitle", "Altyazı", null },
                    { 5151, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "We chose a comedy for the evening.", null, "Comedy", "Komedi", null },
                    { 5152, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The drama moved everyone in the room.", null, "Drama", "Dram", null },
                    { 5153, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The series has four seasons.", null, "Series", "Dizi", null },
                    { 5154, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The last episode airs on Sunday.", null, "Episode", "Bölüm", null },
                    { 5155, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Nobody expected that ending.", null, "Ending", "Son", null },
                    { 5156, null, 6, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "My favourite character appears late.", null, "Character", "Karakter", null },
                    { 5157, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The game takes about ten hours.", null, "Game", "Oyun", null },
                    { 5158, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "He finished the last level yesterday.", null, "Level", "Seviye", null },
                    { 5159, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The console is connected to the television.", null, "Console", "Konsol", null },
                    { 5160, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "My controller needs new batteries.", null, "Controller", "Kumanda", null },
                    { 5161, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "This mission is harder than the others.", null, "Mission", "Görev", null },
                    { 5162, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "You get a reward for finishing early.", null, "Reward", "Ödül", null },
                    { 5163, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The tournament starts next weekend.", null, "Tournament", "Turnuva", null },
                    { 5164, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "She unlocked every achievement.", null, "Achievement", "Başarım", null },
                    { 5165, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The puzzle took me an hour to solve.", null, "Puzzle", "Bulmaca", null },
                    { 5166, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A better strategy would save time.", null, "Strategy", "Strateji", null },
                    { 5167, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "My opponent played very carefully.", null, "Opponent", "Rakip", null },
                    { 5168, null, 8, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "The final challenge is optional.", null, "Challenge", "Meydan okuma", null }
                });

            migrationBuilder.InsertData(
                table: "LessonVocabularies",
                columns: new[] { "LessonID", "WordID" },
                values: new object[,]
                {
                    { 21, 5121 },
                    { 21, 5122 },
                    { 21, 5123 },
                    { 21, 5124 },
                    { 21, 5125 },
                    { 21, 5126 },
                    { 21, 5127 },
                    { 21, 5128 },
                    { 21, 5129 },
                    { 21, 5130 },
                    { 21, 5131 },
                    { 21, 5132 },
                    { 22, 5133 },
                    { 22, 5134 },
                    { 22, 5135 },
                    { 22, 5136 },
                    { 22, 5137 },
                    { 22, 5138 },
                    { 22, 5139 },
                    { 22, 5140 },
                    { 22, 5141 },
                    { 22, 5142 },
                    { 22, 5143 },
                    { 22, 5144 },
                    { 23, 5145 },
                    { 23, 5146 },
                    { 23, 5147 },
                    { 23, 5148 },
                    { 23, 5149 },
                    { 23, 5150 },
                    { 23, 5151 },
                    { 23, 5152 },
                    { 23, 5153 },
                    { 23, 5154 },
                    { 23, 5155 },
                    { 23, 5156 },
                    { 24, 5157 },
                    { 24, 5158 },
                    { 24, 5159 },
                    { 24, 5160 },
                    { 24, 5161 },
                    { 24, 5162 },
                    { 24, 5163 },
                    { 24, 5164 },
                    { 24, 5165 },
                    { 24, 5166 },
                    { 24, 5167 },
                    { 24, 5168 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_CategoryId_DeckId",
                table: "Vocabularies",
                columns: new[] { "CategoryId", "DeckId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Categories_CategoryId",
                table: "Vocabularies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Categories_CategoryId",
                table: "Vocabularies");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_CategoryId_DeckId",
                table: "Vocabularies");

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5121 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5122 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5123 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5124 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5125 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5126 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5127 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5128 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5129 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5130 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5131 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 21, 5132 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5133 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5134 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5135 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5136 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5137 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5138 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5139 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5140 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5141 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5142 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5143 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 22, 5144 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5145 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5146 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5147 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5148 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5149 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5150 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5151 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5152 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5153 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5154 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5155 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 23, 5156 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5157 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5158 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5159 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5160 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5161 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5162 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5163 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5164 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5165 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5166 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5167 });

            migrationBuilder.DeleteData(
                table: "LessonVocabularies",
                keyColumns: new[] { "LessonID", "WordID" },
                keyValues: new object[] { 24, 5168 });

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5121);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5122);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5123);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5124);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5125);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5126);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5127);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5128);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5129);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5130);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5131);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5132);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5133);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5134);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5135);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5136);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5137);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5138);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5139);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5140);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5141);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5142);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5143);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5144);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5145);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5146);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5147);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5148);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5149);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5150);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5151);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5152);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5153);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5154);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5155);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5156);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5157);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5158);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5159);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5160);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5161);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5162);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5163);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5164);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5165);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5166);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5167);

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "WordID",
                keyValue: 5168);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Vocabularies");
        }
    }
}
