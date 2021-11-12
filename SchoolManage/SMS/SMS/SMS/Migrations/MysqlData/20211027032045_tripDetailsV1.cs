using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class tripDetailsV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusTrips_Students_StudentId",
                table: "BusTrips");

            migrationBuilder.DropIndex(
                name: "IX_BusTrips_StudentId",
                table: "BusTrips");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BusTrips");

            migrationBuilder.AddColumn<int>(
                name: "BusTripid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BusTripid",
                table: "Students",
                column: "BusTripid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_BusTrips_BusTripid",
                table: "Students",
                column: "BusTripid",
                principalTable: "BusTrips",
                principalColumn: "BusTripid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_BusTrips_BusTripid",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BusTripid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BusTripid",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "BusTrips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_StudentId",
                table: "BusTrips",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusTrips_Students_StudentId",
                table: "BusTrips",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
