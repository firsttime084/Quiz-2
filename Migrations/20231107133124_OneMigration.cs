using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class OneMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    AnswerGivenIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerText = table.Column<string>(type: "text", nullable: false),
                    Iscorrect = table.Column<bool>(type: "boolean", nullable: false),
                    questionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "AnswerGivenIndex", "QuestionText" },
                values: new object[,]
                {
                    { 1, 0, "What is the result of 1+1?" },
                    { 2, 0, "What is the result of 1-1?" },
                    { 3, 0, "What is the result of 10-5?" },
                    { 4, 0, "What color ir grass?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "Iscorrect", "questionId" },
                values: new object[,]
                {
                    { 1, "2", true, 1 },
                    { 2, "4", false, 1 },
                    { 3, "0", false, 1 },
                    { 4, "10", false, 1 },
                    { 5, "2", false, 2 },
                    { 6, "4", false, 2 },
                    { 7, "0", true, 2 },
                    { 8, "10", false, 2 },
                    { 9, "20", false, 3 },
                    { 10, "5", true, 3 },
                    { 11, "30", false, 3 },
                    { 12, "10", false, 3 },
                    { 13, "Red", false, 4 },
                    { 14, "Green", true, 4 },
                    { 15, "Blue", false, 4 },
                    { 16, "Black", false, 4 },
                    { 17, "Gray", false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_questionId",
                table: "Answers",
                column: "questionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
