using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class BusAndDriverDetails : Migration
    {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "ArrivalTime",
          table: "BusesAndDrivers");

      migrationBuilder.DropColumn(
          name: "BusLocation",
          table: "BusesAndDrivers");

      migrationBuilder.DropColumn(
          name: "BusStatus",
          table: "BusesAndDrivers");
    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
