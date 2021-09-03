using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class TransportInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusTypes",
                columns: table => new
                {
                    BusTypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BusTypeDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTypes", x => x.BusTypeid);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSpans",
                columns: table => new
                {
                    NotificationSpanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NotificationSpanDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSpans", x => x.NotificationSpanId);
                });

            migrationBuilder.CreateTable(
                name: "BusesAndDrivers",
                columns: table => new
                {
                    BusesAndDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BusTypeid = table.Column<int>(type: "int", nullable: true),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    BusNumber = table.Column<int>(type: "int", nullable: false),
                    InsurancePolicyNum = table.Column<int>(type: "int", nullable: false),
                    InsuranceEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NotificationSpanId = table.Column<int>(type: "int", nullable: true),
                    BusStatus = table.Column<string>(type: "text", nullable: true),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DriverName = table.Column<string>(type: "text", nullable: true),
                    DriverNumber = table.Column<int>(type: "int", nullable: false),
                    DriverAadhar = table.Column<int>(type: "int", nullable: false),
                    BusLocation = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusesAndDrivers", x => x.BusesAndDriverId);
                    table.ForeignKey(
                        name: "FK_BusesAndDrivers_BusTypes_BusTypeid",
                        column: x => x.BusTypeid,
                        principalTable: "BusTypes",
                        principalColumn: "BusTypeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusesAndDrivers_NotificationSpans_NotificationSpanId",
                        column: x => x.NotificationSpanId,
                        principalTable: "NotificationSpans",
                        principalColumn: "NotificationSpanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusTrips",
                columns: table => new
                {
                    BusTripid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TripNumber = table.Column<int>(type: "int", nullable: false),
                    TripAreas = table.Column<string>(type: "text", nullable: true),
                    TripTimingFrom = table.Column<TimeSpan>(type: "time", nullable: false),
                    TripTimingTo = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalHeadCount = table.Column<int>(type: "int", nullable: false),
                    BusesAndDriverId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrips", x => x.BusTripid);
                    table.ForeignKey(
                        name: "FK_BusTrips_BusesAndDrivers_BusesAndDriverId",
                        column: x => x.BusesAndDriverId,
                        principalTable: "BusesAndDrivers",
                        principalColumn: "BusesAndDriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusTrips_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusesAndDrivers_BusTypeid",
                table: "BusesAndDrivers",
                column: "BusTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_BusesAndDrivers_NotificationSpanId",
                table: "BusesAndDrivers",
                column: "NotificationSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_BusesAndDriverId",
                table: "BusTrips",
                column: "BusesAndDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_StudentId",
                table: "BusTrips",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusTrips");

            migrationBuilder.DropTable(
                name: "BusesAndDrivers");

            migrationBuilder.DropTable(
                name: "BusTypes");

            migrationBuilder.DropTable(
                name: "NotificationSpans");
        }
    }
}
