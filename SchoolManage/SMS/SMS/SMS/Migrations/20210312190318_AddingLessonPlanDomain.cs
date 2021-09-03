using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class AddingLessonPlanDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonPlans",
                columns: table => new
                {
                    LessonPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonPlanCheckDigi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    classWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    games = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toppic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concept = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.LessonPlanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonPlans");
        }
    }
}
