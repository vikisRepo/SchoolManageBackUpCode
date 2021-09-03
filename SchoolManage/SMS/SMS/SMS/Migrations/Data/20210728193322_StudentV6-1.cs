using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class StudentV61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentUserCred");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentUserCredStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentUserCredStudentId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentUserCredStudentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentUserCred",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserCred", x => x.StudentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId",
                principalTable: "StudentUserCred",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
