using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class InventoryDefectsV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDefects_InventoryItemTypes_InventoryItemTypeId",
                table: "InventoryDefects");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDefects_InventoryItemUsageAreas_InventoryItemUsageA~",
                table: "InventoryDefects");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDefects_InventoryItemTypeId",
                table: "InventoryDefects");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDefects_InventoryItemUsageAreaId",
                table: "InventoryDefects");

            migrationBuilder.DropColumn(
                name: "InventoryItemTypeId",
                table: "InventoryDefects");

            migrationBuilder.DropColumn(
                name: "InventoryItemUsageAreaId",
                table: "InventoryDefects");

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "InventoryDefects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "InventoryDefects",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "InventoryDefects");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "InventoryDefects");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemTypeId",
                table: "InventoryDefects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemUsageAreaId",
                table: "InventoryDefects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDefects_InventoryItemTypeId",
                table: "InventoryDefects",
                column: "InventoryItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDefects_InventoryItemUsageAreaId",
                table: "InventoryDefects",
                column: "InventoryItemUsageAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDefects_InventoryItemTypes_InventoryItemTypeId",
                table: "InventoryDefects",
                column: "InventoryItemTypeId",
                principalTable: "InventoryItemTypes",
                principalColumn: "InventoryItemTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDefects_InventoryItemUsageAreas_InventoryItemUsageA~",
                table: "InventoryDefects",
                column: "InventoryItemUsageAreaId",
                principalTable: "InventoryItemUsageAreas",
                principalColumn: "InventoryItemUsageAreaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
