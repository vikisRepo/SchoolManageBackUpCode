using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class studentfeedback1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdmissionNumber",
                table: "StudentFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "CourseDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmissionNumber",
                table: "StudentFeedbacks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "CourseDetails");
        }
    }
}
