using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class Studentaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCity",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentCountry",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentLine1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentLine2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentLine3",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentPincode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentSate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantCity",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantCountry",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantLine1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantLine2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantLine3",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantPincode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermenantSate",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentAddressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentAddress",
                columns: table => new
                {
                    StudentAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "text", nullable: true),
                    Line2 = table.Column<string>(type: "text", nullable: true),
                    Line3 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Sate = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Pincode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddress", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_StudentAddress_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddress_StudentId",
                table: "StudentAddress",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddress");

            migrationBuilder.DropColumn(
                name: "StudentAddressId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCity",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentCountry",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentLine1",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentLine2",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentLine3",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentPincode",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentSate",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantCity",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantCountry",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantLine1",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantLine2",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantLine3",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantPincode",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermenantSate",
                table: "Students",
                type: "text",
                nullable: true);
        }
    }
}
