using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class SubjectDescr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_Subject",
                table: "Subjects",
                newName: "SubjectDescr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectDescr",
                table: "Subjects",
                newName: "_Subject");
        }
    }
}
