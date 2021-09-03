using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class LessonPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicClassSubjects",
                columns: table => new
                {
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClassSubjects", x => x.AcademicClassSubjectId);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlans",
                columns: table => new
                {
                    LessonPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonPlanCheckDigi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    classWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    games = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concept = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.LessonPlanId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicClasses",
                columns: table => new
                {
                    AcademicClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClasses", x => x.AcademicClassId);
                    table.ForeignKey(
                        name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                        column: x => x.AcademicClassSubjectId,
                        principalTable: "AcademicClassSubjects",
                        principalColumn: "AcademicClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                        column: x => x.AcademicClassSubjectId,
                        principalTable: "AcademicClassSubjects",
                        principalColumn: "AcademicClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicClasses");

            migrationBuilder.DropTable(
                name: "LessonPlans");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AcademicClassSubjects");
        }
    }
}
