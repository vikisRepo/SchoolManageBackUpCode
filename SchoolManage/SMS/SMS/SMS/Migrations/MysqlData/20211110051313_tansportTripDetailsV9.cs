using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class tansportTripDetailsV9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
				name: "FK_Students_BusTrips_BusTripid",
				table: "Students");

			migrationBuilder.AlterColumn<int>(
                name: "BusTripid",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_BusTrips_BusTripid",
                table: "Students",
                column: "BusTripid",
                principalTable: "BusTrips",
                principalColumn: "BusTripid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_BusTrips_BusTripid",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "BusTripid",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_BusTrips_BusTripid",
                table: "Students",
                column: "BusTripid",
                principalTable: "BusTrips",
                principalColumn: "BusTripid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
