using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexiCareManager.Migrations
{
    /// <inheritdoc />
    public partial class PatientProgrammeToSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientProgrammeId",
                table: "Session",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Session_PatientProgrammeId",
                table: "Session",
                column: "PatientProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_PatientProgramme_PatientProgrammeId",
                table: "Session",
                column: "PatientProgrammeId",
                principalTable: "PatientProgramme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_PatientProgramme_PatientProgrammeId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_PatientProgrammeId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PatientProgrammeId",
                table: "Session");
        }
    }
}
