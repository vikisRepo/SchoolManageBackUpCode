using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class StudentAttachmentsUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttachments_Students_StudentId",
                table: "StudentAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttachments",
                table: "StudentAttachments");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttachments_StudentId",
                table: "StudentAttachments");

            migrationBuilder.DropColumn(
                name: "StudentAttachmentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentAttachments");

            migrationBuilder.RenameTable(
                name: "StudentAttachments",
                newName: "StudentDocuments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDocuments",
                table: "StudentDocuments",
                column: "StudentAttachmentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDocuments",
                table: "StudentDocuments");

            migrationBuilder.RenameTable(
                name: "StudentDocuments",
                newName: "StudentAttachments");

            migrationBuilder.AddColumn<int>(
                name: "StudentAttachmentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttachments",
                table: "StudentAttachments",
                column: "StudentAttachmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttachments_StudentId",
                table: "StudentAttachments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttachments_Students_StudentId",
                table: "StudentAttachments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
