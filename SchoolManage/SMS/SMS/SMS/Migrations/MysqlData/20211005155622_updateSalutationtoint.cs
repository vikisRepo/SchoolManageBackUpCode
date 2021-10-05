using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class updateSalutationtoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalutationId",
                table: "Dependents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SalutationId",
                table: "Dependents",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
