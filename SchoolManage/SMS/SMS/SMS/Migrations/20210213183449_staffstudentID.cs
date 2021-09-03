using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class staffstudentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffUserCred_StaffUserCredStaffId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "StaffUserCred");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_StaffUserCredStaffId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffUserCredStaffId",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffId",
                table: "AspNetUsers",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Staffs_StaffId",
                table: "AspNetUsers",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Staffs_StaffId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePic",
                table: "Staffs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffUserCredStaffId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffUserCred",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffUserCred", x => x.StaffId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffUserCredStaffId",
                table: "Staffs",
                column: "StaffUserCredStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffUserCred_StaffUserCredStaffId",
                table: "Staffs",
                column: "StaffUserCredStaffId",
                principalTable: "StaffUserCred",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
