using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class removingFKfromSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicClassSubjectId",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicClassSubjectId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
