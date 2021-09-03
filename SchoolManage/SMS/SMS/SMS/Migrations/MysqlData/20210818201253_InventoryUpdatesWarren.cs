using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class InventoryUpdatesWarren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<bool>(
                name: "WarrenOrGarantee",
                table: "Inventorys",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
                table: "Inventorys");

            migrationBuilder.RenameColumn(
                name: "InventoryItemTypeId",
                table: "Inventorys",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventorys_InventoryItemTypeId",
                table: "Inventorys",
                newName: "IX_Inventorys_ItemTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "WarrenOrGarantee",
                table: "Inventorys",
                type: "text",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventorys_InventoryItemTypes_ItemTypeId",
                table: "Inventorys",
                column: "ItemTypeId",
                principalTable: "InventoryItemTypes",
                principalColumn: "InventoryItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
