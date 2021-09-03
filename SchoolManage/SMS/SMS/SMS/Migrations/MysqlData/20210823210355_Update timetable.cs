using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class Updatetimetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTimeTables",
                columns: table => new
                {
                    ClassTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTimeTables", x => x.ClassTimeTableId);
                });

            migrationBuilder.CreateTable(
                name: "PeriodDetails",
                columns: table => new
                {
                    PeriodDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "text", nullable: true),
                    ClassTimeTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodDetails", x => x.PeriodDetailId);
                    table.ForeignKey(
                        name: "FK_PeriodDetails_ClassTimeTables_ClassTimeTableId",
                        column: x => x.ClassTimeTableId,
                        principalTable: "ClassTimeTables",
                        principalColumn: "ClassTimeTableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodDetails_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodDetails_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetails_ClassTimeTableId",
                table: "PeriodDetails",
                column: "ClassTimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetails_StaffId",
                table: "PeriodDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetails_SubjectID",
                table: "PeriodDetails",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodDetails");

            migrationBuilder.DropTable(
                name: "ClassTimeTables");
        }
    }
}
