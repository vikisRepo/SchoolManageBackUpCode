using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class LeaveInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                table: "AcademicClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses");

            migrationBuilder.DropColumn(
                name: "AcademicClassSubjectId",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicClassSubjectId",
                table: "AcademicClasses",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "StaffLeaves",
                columns: table => new
                {
                    StaffLeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    LeaveType = table.Column<string>(type: "text", nullable: true),
                    datefrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateto = table.Column<DateTime>(type: "datetime", nullable: false),
                    leavesession = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLeaves", x => x.StaffLeaveId);
                    table.ForeignKey(
                        name: "FK_StaffLeaves_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLeaves",
                columns: table => new
                {
                    StudentLeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    LeaveType = table.Column<string>(type: "text", nullable: true),
                    datefrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateto = table.Column<DateTime>(type: "datetime", nullable: false),
                    leavesession = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLeaves", x => x.StudentLeaveId);
                    table.ForeignKey(
                        name: "FK_StudentLeaves_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffLeaves_StaffId",
                table: "StaffLeaves",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLeaves_StudentId",
                table: "StudentLeaves",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffLeaves");

            migrationBuilder.DropTable(
                name: "StudentLeaves");

            migrationBuilder.AddColumn<int>(
                name: "AcademicClassSubjectId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicClassSubjectId",
                table: "AcademicClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId",
                principalTable: "AcademicClassSubjects",
                principalColumn: "AcademicClassSubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
