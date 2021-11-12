using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class tripdetailsv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusTrips_BusesAndDrivers_BusesAndDriverId",
                table: "BusTrips");

            migrationBuilder.AlterColumn<int>(
                name: "BusesAndDriverId",
                table: "BusTrips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTrips_BusesAndDrivers_BusesAndDriverId",
                table: "BusTrips",
                column: "BusesAndDriverId",
                principalTable: "BusesAndDrivers",
                principalColumn: "BusesAndDriverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusTrips_BusesAndDrivers_BusesAndDriverId",
                table: "BusTrips");

            migrationBuilder.AlterColumn<int>(
                name: "BusesAndDriverId",
                table: "BusTrips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BusTrips_BusesAndDrivers_BusesAndDriverId",
                table: "BusTrips",
                column: "BusesAndDriverId",
                principalTable: "BusesAndDrivers",
                principalColumn: "BusesAndDriverId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
