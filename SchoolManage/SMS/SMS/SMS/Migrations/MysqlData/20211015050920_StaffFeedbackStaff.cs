using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class StaffFeedbackStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LanguagesId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StaffDocuments",
                columns: table => new
                {
                    StaffAttachmentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    DocumentType = table.Column<string>(type: "text", nullable: true),
                    PathToFile = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDocuments", x => x.StaffAttachmentsId);
                });

            migrationBuilder.CreateTable(
                name: "StaffFeedbacks",
                columns: table => new
                {
                    StaffFeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Empid = table.Column<string>(type: "text", nullable: true),
                    StaffName = table.Column<string>(type: "text", nullable: true),
                    FeedbackType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: true),
                    TeacherId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Feedbacktitle = table.Column<string>(type: "text", nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffFeedbacks", x => x.StaffFeedbackID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffDocuments");

            migrationBuilder.DropTable(
                name: "StaffFeedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "LanguagesId",
                table: "Staffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
