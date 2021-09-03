using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class LessonPlanAcademicIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "toppic",
                table: "LessonPlans",
                newName: "topic");

            migrationBuilder.AddColumn<int>(
                name: "AcademicClassId",
                table: "LessonPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicClassSubjectId",
                table: "LessonPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicClassId",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "AcademicClassSubjectId",
                table: "LessonPlans");

            migrationBuilder.RenameColumn(
                name: "topic",
                table: "LessonPlans",
                newName: "toppic");
        }
    }
}
