using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class factorydataV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bloodgroups",
                keyColumn: "BloodgroupId",
                keyValue: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bloodgroups",
                columns: new[] { "BloodgroupId", "BloodgroupName" },
                values: new object[] { 9, "Vice Principal" });
        }
    }
}
