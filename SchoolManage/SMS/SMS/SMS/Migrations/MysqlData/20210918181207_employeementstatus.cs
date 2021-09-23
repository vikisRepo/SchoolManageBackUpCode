using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class employeementstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeementStatus",
                table: "EmployeementStatus");

            migrationBuilder.RenameTable(
                name: "EmployeementStatus",
                newName: "EmployeementStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeementStatuses",
                table: "EmployeementStatuses",
                column: "EmployeementStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeementStatuses",
                table: "EmployeementStatuses");

            migrationBuilder.RenameTable(
                name: "EmployeementStatuses",
                newName: "EmployeementStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeementStatus",
                table: "EmployeementStatus",
                column: "EmployeementStatusId");
        }
    }
}
