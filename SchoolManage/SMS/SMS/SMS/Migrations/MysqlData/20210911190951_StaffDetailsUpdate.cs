using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class StaffDetailsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "branchnumber",
                table: "Staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maritalStatus",
                table: "Staffs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchnumber",
                table: "Staffs");


            migrationBuilder.DropColumn(
                name: "maritalStatus",
                table: "Staffs");

        }
    }
}
