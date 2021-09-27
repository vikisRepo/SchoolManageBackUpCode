using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class updateStaffAttendanceV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "StaffAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowInactive",
                table: "StaffAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffTypeId",
                table: "StaffAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "RowInactive",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "StaffTypeId",
                table: "StaffAttendances");
        }
    }
}
