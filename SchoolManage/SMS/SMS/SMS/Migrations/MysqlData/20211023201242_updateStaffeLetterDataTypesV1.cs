using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class updateStaffeLetterDataTypesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Month",
                table: "StaffeLetters",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "StaffeLetters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
