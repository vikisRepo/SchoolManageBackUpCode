using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class employeementstatusseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeementStatus",
                columns: table => new
                {
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeementStatus", x => x.EmployeementStatusId);
                });

            migrationBuilder.InsertData(
                table: "EmployeementStatus",
                columns: new[] { "EmployeementStatusId", "Description" },
                values: new object[,]
                {
                    { 1, " Active" },
                    { 2, " In active" },
                    { 3, " Terminated" },
                    { 4, " In Leave" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeementStatus");
        }
    }
}
