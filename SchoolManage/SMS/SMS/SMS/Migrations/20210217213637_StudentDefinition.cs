using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class StudentDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FathersAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FathersSalutation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianSalary",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LegalGaurdianSalutation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianSalary",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocalGaurdianSalutation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersAadharNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersAnnualIncome",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersCompany",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersDesignation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersMiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersMobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MothersSalutation",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DependentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    DependentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DependentsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    BvEmployee = table.Column<bool>(type: "bit", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.DependentsId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Dependents_DependentsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropIndex(
                name: "IX_Students_DependentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DependentsId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FathersAadharNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FathersAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FathersCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersDesignation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersEmail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersMiddleName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersMobileNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersOccupation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FathersSalutation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianAadharNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LegalGaurdianAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianDesignation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianMiddleName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianMobileNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianOccupation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianSalary",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalGaurdianSalutation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianAadharNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocalGaurdianAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianDesignation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianMiddleName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianMobileNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianOccupation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianSalary",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalGaurdianSalutation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherEmail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersAadharNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MothersAnnualIncome",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "MothersCompany",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersDesignation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersMiddleName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersMobileNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersOccupation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersSalutation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
