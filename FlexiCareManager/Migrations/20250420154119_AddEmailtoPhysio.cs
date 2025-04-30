using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexiCareManager.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailtoPhysio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Physio",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Physio");
        }
    }
}
