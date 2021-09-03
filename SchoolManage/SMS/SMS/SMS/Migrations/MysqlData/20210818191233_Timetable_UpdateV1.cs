using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class Timetable_UpdateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetail_ClassTimeTables_ClassTimeTableId",
                table: "PeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetail_Staffs_StaffId",
                table: "PeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetail_Subjects_SubjectID",
                table: "PeriodDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeriodDetail",
                table: "PeriodDetail");

            migrationBuilder.DropIndex(
                name: "IX_PeriodDetail_ClassTimeTableId",
                table: "PeriodDetail");

            migrationBuilder.DropColumn(
                name: "PeriodDetailsId",
                table: "ClassTimeTables");

            migrationBuilder.RenameTable(
                name: "PeriodDetail",
                newName: "PeriodDetails");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodDetail_SubjectID",
                table: "PeriodDetails",
                newName: "IX_PeriodDetails_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodDetail_StaffId",
                table: "PeriodDetails",
                newName: "IX_PeriodDetails_StaffId");

            migrationBuilder.AddColumn<int>(
                name: "PeriodDetailId",
                table: "ClassTimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassTimeTableId",
                table: "PeriodDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeriodDetails",
                table: "PeriodDetails",
                column: "PeriodDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTables_PeriodDetailId",
                table: "ClassTimeTables",
                column: "PeriodDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTimeTables_PeriodDetails_PeriodDetailId",
                table: "ClassTimeTables",
                column: "PeriodDetailId",
                principalTable: "PeriodDetails",
                principalColumn: "PeriodDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetails_Staffs_StaffId",
                table: "PeriodDetails",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetails_Subjects_SubjectID",
                table: "PeriodDetails",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTimeTables_PeriodDetails_PeriodDetailId",
                table: "ClassTimeTables");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetails_Staffs_StaffId",
                table: "PeriodDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetails_Subjects_SubjectID",
                table: "PeriodDetails");

            migrationBuilder.DropIndex(
                name: "IX_ClassTimeTables_PeriodDetailId",
                table: "ClassTimeTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeriodDetails",
                table: "PeriodDetails");

            migrationBuilder.DropColumn(
                name: "PeriodDetailId",
                table: "ClassTimeTables");

            migrationBuilder.RenameTable(
                name: "PeriodDetails",
                newName: "PeriodDetail");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodDetails_SubjectID",
                table: "PeriodDetail",
                newName: "IX_PeriodDetail_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodDetails_StaffId",
                table: "PeriodDetail",
                newName: "IX_PeriodDetail_StaffId");

            migrationBuilder.AddColumn<int>(
                name: "PeriodDetailsId",
                table: "ClassTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClassTimeTableId",
                table: "PeriodDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeriodDetail",
                table: "PeriodDetail",
                column: "PeriodDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetail_ClassTimeTableId",
                table: "PeriodDetail",
                column: "ClassTimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetail_ClassTimeTables_ClassTimeTableId",
                table: "PeriodDetail",
                column: "ClassTimeTableId",
                principalTable: "ClassTimeTables",
                principalColumn: "ClassTimeTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetail_Staffs_StaffId",
                table: "PeriodDetail",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetail_Subjects_SubjectID",
                table: "PeriodDetail",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
