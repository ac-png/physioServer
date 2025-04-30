using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexiCareManager.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowToPerform",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MusclesWorked",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reps",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rest",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sets",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tips",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "HowToPerform",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "MusclesWorked",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Rest",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Tips",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Exercise");
        }
    }
}
