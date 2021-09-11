using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class Staffexperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffExperience_Staffs_StaffId",
                table: "StaffExperience");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "StaffExperience",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffExperience_Staffs_StaffId",
                table: "StaffExperience",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffExperience_Staffs_StaffId",
                table: "StaffExperience");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "StaffExperience",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffExperience_Staffs_StaffId",
                table: "StaffExperience",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
