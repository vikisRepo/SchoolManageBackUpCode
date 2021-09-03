using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunctions_Functions_FunctionId",
                table: "RoleFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunctions_Role_RoleId",
                table: "RoleFunctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleFunctions",
                table: "RoleFunctions");

            migrationBuilder.RenameTable(
                name: "RoleFunctions",
                newName: "RoleFunction");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "StaffUserCreds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "StaffUserCreds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleFunction",
                table: "RoleFunction",
                column: "RoleFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunction_Functions_FunctionId",
                table: "RoleFunction",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "FunctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunction_Role_RoleId",
                table: "RoleFunction",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunction_Functions_FunctionId",
                table: "RoleFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFunction_Role_RoleId",
                table: "RoleFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleFunction",
                table: "RoleFunction");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "RoleFunction",
                newName: "RoleFunctions");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "StaffUserCreds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "StaffUserCreds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleFunctions",
                table: "RoleFunctions",
                column: "RoleFunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunctions_Functions_FunctionId",
                table: "RoleFunctions",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "FunctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFunctions_Role_RoleId",
                table: "RoleFunctions",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
