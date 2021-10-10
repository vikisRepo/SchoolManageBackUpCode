using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class StudentFeedbackV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "StudentFeedbacks");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "StudentFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "StudentFeedbacks");

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "StudentFeedbacks",
                type: "text",
                nullable: true);
        }
    }
}
