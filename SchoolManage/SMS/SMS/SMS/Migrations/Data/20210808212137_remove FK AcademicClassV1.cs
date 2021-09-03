using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class removeFKAcademicClassV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                table: "AcademicClasses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicClassSubjectId",
                table: "AcademicClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AcademicClassSubjectId",
                table: "AcademicClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
