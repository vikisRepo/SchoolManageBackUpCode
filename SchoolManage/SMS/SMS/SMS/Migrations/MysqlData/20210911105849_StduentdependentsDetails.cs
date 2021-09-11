using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class StduentdependentsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetails_Staffs_StaffId",
                table: "PeriodDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetails_Subjects_SubjectID",
                table: "PeriodDetails");

            migrationBuilder.DropColumn(
                name: "FatherAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherBvEmployee",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherSalutationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalBvEmployee",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalSalutationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianBvEmployee",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGuardianSalutationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherBvEmployee",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherSalutationId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DependentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "PeriodDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "PeriodDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    DependentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "text", nullable: true),
                    SalutationId = table.Column<string>(type: "text", nullable: true),
                    AadharNumber = table.Column<string>(type: "text", nullable: true),
                    AnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    BvEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: true),
                    Designation = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.DependentsId);
                });

            migrationBuilder.CreateTable(
                name: "DependentsStudent",
                columns: table => new
                {
                    DependentsdetailsDependentsId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentsStudent", x => new { x.DependentsdetailsDependentsId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_DependentsStudent_Dependents_DependentsdetailsDependentsId",
                        column: x => x.DependentsdetailsDependentsId,
                        principalTable: "Dependents",
                        principalColumn: "DependentsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DependentsStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependentsStudent_StudentsStudentId",
                table: "DependentsStudent",
                column: "StudentsStudentId");

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
                name: "FK_PeriodDetails_Staffs_StaffId",
                table: "PeriodDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodDetails_Subjects_SubjectID",
                table: "PeriodDetails");

            migrationBuilder.DropTable(
                name: "DependentsStudent");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropColumn(
                name: "DependentsId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FatherAadharNumber",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FatherAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "FatherBvEmployee",
                table: "Students",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FatherCompany",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherDesignation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherEmail",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherFirstName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherLastName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherMiddleName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FatherMobileNumber",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FatherOccupation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherSalutationId",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAadharNumber",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LegalAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "LegalBvEmployee",
                table: "Students",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalCompany",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalDesignation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalEmail",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalFirstName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalLastName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalMiddleName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LegalMobileNumber",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LegalOccupation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalSalutationId",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianAadharNumber",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocalGuardianAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "LocalGuardianBvEmployee",
                table: "Students",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianCompany",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianDesignation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianEmail",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianFirstName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianLastName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianMiddleName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocalGuardianMobileNumber",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianOccupation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGuardianSalutationId",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherAadharNumber",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MotherAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "MotherBvEmployee",
                table: "Students",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MotherCompany",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherDesignation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherEmail",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherFirstName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherLastName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherMiddleName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MotherMobileNumber",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "MotherOccupation",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherSalutationId",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "PeriodDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "PeriodDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetails_Staffs_StaffId",
                table: "PeriodDetails",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodDetails_Subjects_SubjectID",
                table: "PeriodDetails",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
