using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class InventoryIntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItemTypes",
                columns: table => new
                {
                    InventoryItemTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemTypes", x => x.InventoryItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemUsageAreas",
                columns: table => new
                {
                    InventoryItemUsageAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemUsageAreas", x => x.InventoryItemUsageAreaId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDefects",
                columns: table => new
                {
                    InventoryDefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InventoryItemTypeId = table.Column<int>(type: "int", nullable: true),
                    InventoryItemUsageAreaId = table.Column<int>(type: "int", nullable: true),
                    DefectInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDefects", x => x.InventoryDefectId);
                    table.ForeignKey(
                        name: "FK_InventoryDefects_InventoryItemTypes_InventoryItemTypeId",
                        column: x => x.InventoryItemTypeId,
                        principalTable: "InventoryItemTypes",
                        principalColumn: "InventoryItemTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDefects_InventoryItemUsageAreas_InventoryItemUsageA~",
                        column: x => x.InventoryItemUsageAreaId,
                        principalTable: "InventoryItemUsageAreas",
                        principalColumn: "InventoryItemUsageAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventorys",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ItemCode = table.Column<string>(type: "text", nullable: true),
                    ItemName = table.Column<string>(type: "text", nullable: true),
                    ModelNumber = table.Column<int>(type: "int", nullable: false),
                    InventoryItemTypeId = table.Column<int>(type: "int", nullable: true),
                    InventoryItemUsageAreaId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WarrenOrGarantee = table.Column<int>(type: "int", nullable: false),
                    WarrenOrGarenInfo = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    VendorNumber = table.Column<int>(type: "int", nullable: false),
                    VendorName = table.Column<string>(type: "text", nullable: true),
                    VendorAddress = table.Column<string>(type: "text", nullable: true),
                    BillCopy = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventorys", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventorys_InventoryItemTypes_InventoryItemTypeId",
                        column: x => x.InventoryItemTypeId,
                        principalTable: "InventoryItemTypes",
                        principalColumn: "InventoryItemTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventorys_InventoryItemUsageAreas_InventoryItemUsageAreaId",
                        column: x => x.InventoryItemUsageAreaId,
                        principalTable: "InventoryItemUsageAreas",
                        principalColumn: "InventoryItemUsageAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDefects_InventoryItemTypeId",
                table: "InventoryDefects",
                column: "InventoryItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDefects_InventoryItemUsageAreaId",
                table: "InventoryDefects",
                column: "InventoryItemUsageAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventorys_InventoryItemTypeId",
                table: "Inventorys",
                column: "InventoryItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventorys_InventoryItemUsageAreaId",
                table: "Inventorys",
                column: "InventoryItemUsageAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDefects");

            migrationBuilder.DropTable(
                name: "Inventorys");

            migrationBuilder.DropTable(
                name: "InventoryItemTypes");

            migrationBuilder.DropTable(
                name: "InventoryItemUsageAreas");
        }
    }
}
