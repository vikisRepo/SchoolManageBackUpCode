using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class courseSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicClassId",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicClassSubjectId",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicClassId",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "AcademicClassSubjectId",
                table: "CourseDetails");
        }
    }
}
