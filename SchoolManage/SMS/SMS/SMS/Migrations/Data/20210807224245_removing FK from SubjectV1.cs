using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class removingFKfromSubjectV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AcademicClassSubjectId",
                table: "Subjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicClassSubjectId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
