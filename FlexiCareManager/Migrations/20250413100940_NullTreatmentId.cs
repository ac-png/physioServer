using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexiCareManager.Migrations
{
    /// <inheritdoc />
    public partial class NullTreatmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeTreatment_Programme_ProgrammeId",
                table: "ProgrammeTreatment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeTreatment_Treatment_TreatmentId",
                table: "ProgrammeTreatment");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "ProgrammeTreatment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "ProgrammeTreatment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeTreatment_Programme_ProgrammeId",
                table: "ProgrammeTreatment",
                column: "ProgrammeId",
                principalTable: "Programme",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeTreatment_Treatment_TreatmentId",
                table: "ProgrammeTreatment",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeTreatment_Programme_ProgrammeId",
                table: "ProgrammeTreatment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeTreatment_Treatment_TreatmentId",
                table: "ProgrammeTreatment");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "ProgrammeTreatment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "ProgrammeTreatment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeTreatment_Programme_ProgrammeId",
                table: "ProgrammeTreatment",
                column: "ProgrammeId",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeTreatment_Treatment_TreatmentId",
                table: "ProgrammeTreatment",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
