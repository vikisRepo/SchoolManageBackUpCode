using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class AddressUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "AddressStaff");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Staffs",
                newName: "StaffAddressId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Addresses",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Addresses",
                newName: "StudentAddressId");

            migrationBuilder.AddColumn<int>(
                name: "StudentAddressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StaffAddress",
                columns: table => new
                {
                    StaffAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAddress", x => x.StaffAddressId);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_StaffId",
                table: "StaffAddress",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "StaffAddress");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StudentAddressId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StaffAddressId",
                table: "Staffs",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Addresses",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "StudentAddressId",
                table: "Addresses",
                newName: "AddressId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressStaff",
                columns: table => new
                {
                    CurrentAddressAddressId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressStaff", x => new { x.CurrentAddressAddressId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_AddressStaff_Addresses_CurrentAddressAddressId",
                        column: x => x.CurrentAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressStaff_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressStaff_StaffId",
                table: "AddressStaff",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
