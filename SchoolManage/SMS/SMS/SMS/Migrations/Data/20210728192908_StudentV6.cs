using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class StudentV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentUserCred",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserCred", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentUserCredStudentId = table.Column<int>(type: "int", nullable: true),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    AdmissionNumber = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    schoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    schoolBrand = table.Column<int>(type: "int", nullable: true),
                    passingOutSchool = table.Column<int>(type: "int", nullable: true),
                    yearofattendence = table.Column<int>(type: "int", nullable: true),
                    AcademicPrecentage = table.Column<int>(type: "int", nullable: false),
                    ReasonForLeaving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TransferCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BirthCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Passport = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Aadhar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RationCard = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StudentVisa = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CurrentLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentSate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantSate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermenantPincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherSalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    FatherBvEmployee = table.Column<bool>(type: "bit", nullable: false),
                    FatherCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherSalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    MotherBvEmployee = table.Column<bool>(type: "bit", nullable: false),
                    MotherCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    LegalOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalSalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LegalBvEmployee = table.Column<bool>(type: "bit", nullable: false),
                    LegalCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    LocalGuardianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianSalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LocalGuardianBvEmployee = table.Column<bool>(type: "bit", nullable: false),
                    LocalGuardianCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                        column: x => x.StudentUserCredStudentId,
                        principalTable: "StudentUserCred",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentUserCred");
        }
    }
}
