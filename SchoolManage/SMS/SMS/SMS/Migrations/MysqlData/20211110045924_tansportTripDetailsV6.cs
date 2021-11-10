using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class tansportTripDetailsV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Students_BusTrips_BusTripid",
            //    table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BusTripid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BusTripid",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusTripid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BusTripid",
                table: "Students",
                column: "BusTripid");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Students_BusTrips_BusTripid",
            //    table: "Students",
            //    column: "BusTripid",
            //    principalTable: "BusTrips",
            //    principalColumn: "BusTripid",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
