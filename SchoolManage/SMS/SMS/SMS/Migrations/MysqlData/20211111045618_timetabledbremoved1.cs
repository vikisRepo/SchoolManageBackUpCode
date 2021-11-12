using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class timetabledbremoved1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodDetails");

            migrationBuilder.DropTable(
                name: "ClassTimeTables");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DriverNumber",
                table: "BusesAndDrivers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "BusesAndDrivers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "BusLocation",
                table: "BusesAndDrivers",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "BusStatus",
                table: "BusesAndDrivers",
                type: "text",
                nullable: true);

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
                    ClassTimeTableId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "text", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodDetails_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
