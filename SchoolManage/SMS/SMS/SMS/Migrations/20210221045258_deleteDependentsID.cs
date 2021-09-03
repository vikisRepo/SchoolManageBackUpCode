using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class deleteDependentsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Dependents_DependentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DependentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DependentsId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "FatherDetailsDependentsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FatherDetailsDependentsId",
                table: "Students",
                column: "FatherDetailsDependentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Dependents_FatherDetailsDependentsId",
                table: "Students",
                column: "FatherDetailsDependentsId",
                principalTable: "Dependents",
                principalColumn: "DependentsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Dependents_FatherDetailsDependentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FatherDetailsDependentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherDetailsDependentsId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DependentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DependentsId",
                table: "Students",
                column: "DependentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Dependents_DependentsId",
                table: "Students",
                column: "DependentsId",
                principalTable: "Dependents",
                principalColumn: "DependentsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
