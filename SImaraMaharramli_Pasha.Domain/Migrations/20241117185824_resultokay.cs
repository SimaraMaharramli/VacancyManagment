using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SImaraMaharramli_Pasha.Domain.Migrations
{
    /// <inheritdoc />
    public partial class resultokay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncorrectAnswers",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnansweredQuestions",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncorrectAnswers",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "UnansweredQuestions",
                table: "TestResults");
        }
    }
}
