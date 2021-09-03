using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class NationalityInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PeriodDetail");

            //migrationBuilder.DropTable(
            //    name: "ClassTimeTable");

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NationalityName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.CreateTable(
                name: "ClassTimeTable",
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
                    table.PrimaryKey("PK_ClassTimeTable", x => x.ClassTimeTableId);
                });

            migrationBuilder.CreateTable(
                name: "PeriodDetail",
                columns: table => new
                {
                    PeriodDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClassTimeTableId = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodDetail", x => x.PeriodDetailId);
                    table.ForeignKey(
                        name: "FK_PeriodDetail_ClassTimeTable_ClassTimeTableId",
                        column: x => x.ClassTimeTableId,
                        principalTable: "ClassTimeTable",
                        principalColumn: "ClassTimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodDetail_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodDetail_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetail_ClassTimeTableId",
                table: "PeriodDetail",
                column: "ClassTimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetail_StaffId",
                table: "PeriodDetail",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetail_SubjectID",
                table: "PeriodDetail",
                column: "SubjectID");
        }
    }
}
