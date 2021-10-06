using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class createStaffItemTypeandItemUsageArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 1,
                column: "Description",
                value: "Stationery");

            migrationBuilder.InsertData(
                table: "InventoryItemTypes",
                columns: new[] { "InventoryItemTypeId", "Description" },
                values: new object[,]
                {
                    { 2, "Chair" },
                    { 31, "Swimming pool Kit" },
                    { 30, "Sports Kit" },
                    { 29, "Room Screen" },
                    { 28, "Celebration Kit" },
                    { 27, "Water Doctor" },
                    { 26, "AC" },
                    { 25, "Generator" },
                    { 24, "Kitchen Utensils" },
                    { 22, "Paint" },
                    { 21, "Specimen" },
                    { 20, "Laboratory Product" },
                    { 19, "Lab Chemicals" },
                    { 18, "Projector" },
                    { 23, "Hardwares" },
                    { 16, "Xerox Machine" },
                    { 17, "Bathroom Items" },
                    { 4, "Plumbing Tools" },
                    { 5, "Light" },
                    { 6, "Gadgets" },
                    { 7, "Fan" },
                    { 8, "Board" },
                    { 3, "Bench" },
                    { 10, "Printer" },
                    { 11, "Computer" },
                    { 12, "Laptops" },
                    { 13, "IT Accesories" },
                    { 14, "Office items" },
                    { 15, "Paper" },
                    { 9, "Medicines" }
                });

            migrationBuilder.UpdateData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 1,
                column: "Description",
                value: "Lab");

            migrationBuilder.InsertData(
                table: "InventoryItemUsageAreas",
                columns: new[] { "InventoryItemUsageAreaId", "Description" },
                values: new object[,]
                {
                    { 4, "General" },
                    { 2, "Office" },
                    { 6, "Sports room" },
                    { 7, "Swimming pool" },
                    { 8, "Play area" },
                    { 9, "Server room" },
                    { 10, "Hall" },
                    { 11, "Veranda" },
                    { 12, "Common area" },
                    { 3, "Class" },
                    { 5, "Bathroom" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "InventoryItemTypes",
                keyColumn: "InventoryItemTypeId",
                keyValue: 1,
                column: "Description",
                value: "Furniture");

            migrationBuilder.UpdateData(
                table: "InventoryItemUsageAreas",
                keyColumn: "InventoryItemUsageAreaId",
                keyValue: 1,
                column: "Description",
                value: "Computer Lab");
        }
    }
}
