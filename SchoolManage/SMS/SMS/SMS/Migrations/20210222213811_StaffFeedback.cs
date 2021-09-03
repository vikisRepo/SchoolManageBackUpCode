using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class StaffFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffFeedbacks",
                columns: table => new
                {
                    StaffFeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBackType = table.Column<int>(type: "int", nullable: false),
                    FeedBackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffFeedbacks", x => x.StaffFeedbackID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffFeedbacks");
        }
    }
}
