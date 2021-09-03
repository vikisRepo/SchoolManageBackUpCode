using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class InventoryUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventorys_InventoryItemTypes_ItemTypeId",
                table: "Inventorys");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Inventorys",
                newName: "InventoryItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventorys_ItemTypeId",
                table: "Inventorys",
                newName: "IX_Inventorys_InventoryItemTypeId");

			//migrationBuilder.AddForeignKey(
			//	name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
			//	table: "Inventorys",
			//	column: "InventoryItemTypeId",
			//	principalTable: "InventoryItemTypes",
			//	principalColumn: "InventoryItemTypeId",
			//	onDelete: ReferentialAction.Cascade);
		}
    }
}
