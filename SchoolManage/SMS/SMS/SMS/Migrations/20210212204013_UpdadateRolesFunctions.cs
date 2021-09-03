using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class UpdadateRolesFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunction_Functions_FunctionId",
                table: "RoleFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffUserCreds_StaffUserCredStaffId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentUserCreds_StudentUserCredStudentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentUserCreds",
                table: "StudentUserCreds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffUserCreds",
                table: "StaffUserCreds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Functions",
                table: "Functions");

            migrationBuilder.RenameTable(
                name: "StudentUserCreds",
                newName: "StudentUserCred");

            migrationBuilder.RenameTable(
                name: "StaffUserCreds",
                newName: "StaffUserCred");

            migrationBuilder.RenameTable(
                name: "Functions",
                newName: "Function");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentUserCred",
                table: "StudentUserCred",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffUserCred",
                table: "StaffUserCred",
                column: "StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Function",
                table: "Function",
                column: "FunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunction_Function_FunctionId",
                table: "RoleFunction",
                column: "FunctionId",
                principalTable: "Function",
                principalColumn: "FunctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffUserCred_StaffUserCredStaffId",
                table: "Staffs",
                column: "StaffUserCredStaffId",
                principalTable: "StaffUserCred",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId",
                principalTable: "StudentUserCred",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunction_Function_FunctionId",
                table: "RoleFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffUserCred_StaffUserCredStaffId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentUserCred",
                table: "StudentUserCred");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffUserCred",
                table: "StaffUserCred");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Function",
                table: "Function");

            migrationBuilder.RenameTable(
                name: "StudentUserCred",
                newName: "StudentUserCreds");

            migrationBuilder.RenameTable(
                name: "StaffUserCred",
                newName: "StaffUserCreds");

            migrationBuilder.RenameTable(
                name: "Function",
                newName: "Functions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentUserCreds",
                table: "StudentUserCreds",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffUserCreds",
                table: "StaffUserCreds",
                column: "StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Functions",
                table: "Functions",
                column: "FunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunction_Functions_FunctionId",
                table: "RoleFunction",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "FunctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffUserCreds_StaffUserCredStaffId",
                table: "Staffs",
                column: "StaffUserCredStaffId",
                principalTable: "StaffUserCreds",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentUserCreds_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId",
                principalTable: "StudentUserCreds",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
