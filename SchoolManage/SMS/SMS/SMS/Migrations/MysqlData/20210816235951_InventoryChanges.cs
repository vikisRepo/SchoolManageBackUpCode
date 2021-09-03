using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class InventoryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
            //    table: "Inventorys",
            //    column: "InventoryItemTypeId",
            //    principalTable: "InventoryItemTypes",
            //    principalColumn: "InventoryItemTypeId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inventorys_InventoryItemUsageAreas_InventoryItemUsageAreaId",
            //    table: "Inventorys",
            //    column: "InventoryItemUsageAreaId",
            //    principalTable: "InventoryItemUsageAreas",
            //    principalColumn: "InventoryItemUsageAreaId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
            //    table: "Inventorys");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Inventorys_InventoryItemUsageAreas_InventoryItemUsageAreaId",
            //    table: "Inventorys");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemUsageAreaId",
                table: "Inventorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemTypeId",
                table: "Inventorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte>(
                name: "BillCopy",
                table: "Inventorys",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Inventorys",
                type: "text",
                nullable: true);

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

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
            //    table: "Inventorys",
            //    column: "InventoryItemTypeId",
            //    principalTable: "InventoryItemTypes",
            //    principalColumn: "InventoryItemTypeId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inventorys_InventoryItemUsageAreas_InventoryItemUsageAreaId",
            //    table: "Inventorys",
            //    column: "InventoryItemUsageAreaId",
            //    principalTable: "InventoryItemUsageAreas",
            //    principalColumn: "InventoryItemUsageAreaId",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
