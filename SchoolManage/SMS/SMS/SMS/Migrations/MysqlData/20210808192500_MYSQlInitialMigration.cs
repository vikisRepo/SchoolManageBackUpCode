using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class MYSQlInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicClassSubjects",
                columns: table => new
                {
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClassSubjects", x => x.AcademicClassSubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    AcceptTerms = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    VerificationToken = table.Column<string>(type: "text", nullable: true),
                    Verified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ResetToken = table.Column<string>(type: "text", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordReset = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlans",
                columns: table => new
                {
                    LessonPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonPlanCheckDigi = table.Column<string>(type: "text", nullable: true),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    classWork = table.Column<string>(type: "text", nullable: true),
                    homeWork = table.Column<string>(type: "text", nullable: true),
                    lesson = table.Column<string>(type: "text", nullable: true),
                    games = table.Column<string>(type: "text", nullable: true),
                    activity = table.Column<string>(type: "text", nullable: true),
                    classActivity = table.Column<string>(type: "text", nullable: true),
                    topic = table.Column<string>(type: "text", nullable: true),
                    extraInfo = table.Column<string>(type: "text", nullable: true),
                    concept = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.LessonPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    SalutationId = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    BloodGroup = table.Column<string>(type: "text", nullable: true),
                    Marritalsatus = table.Column<string>(type: "text", nullable: true),
                    WeddingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    MotherTongue = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "text", nullable: true),
                    AadharNumber = table.Column<string>(type: "text", nullable: true),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    MotherName = table.Column<string>(type: "text", nullable: true),
                    SpouseName = table.Column<string>(type: "text", nullable: true),
                    FatherOccupation = table.Column<string>(type: "text", nullable: true),
                    MotherOccupation = table.Column<string>(type: "text", nullable: true),
                    SpouseOccupation = table.Column<string>(type: "text", nullable: true),
                    FatherMobileNumber = table.Column<string>(type: "text", nullable: true),
                    MotherMobileNumber = table.Column<string>(type: "text", nullable: true),
                    SpouseMobileNumber = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BankBranch = table.Column<string>(type: "text", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "text", nullable: true),
                    BankIfscCode = table.Column<string>(type: "text", nullable: true),
                    PanNumber = table.Column<string>(type: "text", nullable: true),
                    StaffAddressId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<string>(type: "text", nullable: true),
                    StaffTypeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficialEmailId = table.Column<string>(type: "text", nullable: true),
                    Esinumber = table.Column<string>(type: "text", nullable: true),
                    Epfnumber = table.Column<string>(type: "text", nullable: true),
                    ReportingTo = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActiveId = table.Column<int>(type: "int", nullable: false),
                    Uannumber = table.Column<string>(type: "text", nullable: true),
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Salutation = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    BloodGroup = table.Column<string>(type: "text", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    EmailId = table.Column<string>(type: "text", nullable: true),
                    AadharNumber = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    AdmissionNumber = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    RollNo = table.Column<string>(type: "text", nullable: true),
                    FirstLanguage = table.Column<string>(type: "text", nullable: true),
                    SecondLanguage = table.Column<string>(type: "text", nullable: true),
                    EmisNumber = table.Column<string>(type: "text", nullable: true),
                    schoolName = table.Column<string>(type: "text", nullable: true),
                    schoolBrand = table.Column<int>(type: "int", nullable: true),
                    passingOutSchool = table.Column<int>(type: "int", nullable: true),
                    yearofattendence = table.Column<int>(type: "int", nullable: true),
                    AcademicPrecentage = table.Column<int>(type: "int", nullable: false),
                    ReasonForLeaving = table.Column<string>(type: "text", nullable: true),
                    CurrentLine1 = table.Column<string>(type: "text", nullable: true),
                    CurrentLine2 = table.Column<string>(type: "text", nullable: true),
                    CurrentLine3 = table.Column<string>(type: "text", nullable: true),
                    CurrentCity = table.Column<string>(type: "text", nullable: true),
                    CurrentSate = table.Column<string>(type: "text", nullable: true),
                    CurrentCountry = table.Column<string>(type: "text", nullable: true),
                    CurrentPincode = table.Column<string>(type: "text", nullable: true),
                    PermenantLine1 = table.Column<string>(type: "text", nullable: true),
                    PermenantLine2 = table.Column<string>(type: "text", nullable: true),
                    PermenantLine3 = table.Column<string>(type: "text", nullable: true),
                    PermenantCity = table.Column<string>(type: "text", nullable: true),
                    PermenantSate = table.Column<string>(type: "text", nullable: true),
                    PermenantCountry = table.Column<string>(type: "text", nullable: true),
                    PermenantPincode = table.Column<string>(type: "text", nullable: true),
                    FatherFirstName = table.Column<string>(type: "text", nullable: true),
                    FatherLastName = table.Column<string>(type: "text", nullable: true),
                    FatherMiddleName = table.Column<string>(type: "text", nullable: true),
                    FatherMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    FatherOccupation = table.Column<string>(type: "text", nullable: true),
                    FatherSalutationId = table.Column<string>(type: "text", nullable: true),
                    FatherAadharNumber = table.Column<string>(type: "text", nullable: true),
                    FatherAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    FatherBvEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FatherCompany = table.Column<string>(type: "text", nullable: true),
                    FatherDesignation = table.Column<string>(type: "text", nullable: true),
                    FatherEmail = table.Column<string>(type: "text", nullable: true),
                    MotherFirstName = table.Column<string>(type: "text", nullable: true),
                    MotherLastName = table.Column<string>(type: "text", nullable: true),
                    MotherMiddleName = table.Column<string>(type: "text", nullable: true),
                    MotherMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    MotherOccupation = table.Column<string>(type: "text", nullable: true),
                    MotherSalutationId = table.Column<string>(type: "text", nullable: true),
                    MotherAadharNumber = table.Column<string>(type: "text", nullable: true),
                    MotherAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    MotherBvEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MotherCompany = table.Column<string>(type: "text", nullable: true),
                    MotherDesignation = table.Column<string>(type: "text", nullable: true),
                    MotherEmail = table.Column<string>(type: "text", nullable: true),
                    LegalFirstName = table.Column<string>(type: "text", nullable: true),
                    LegalLastName = table.Column<string>(type: "text", nullable: true),
                    LegalMiddleName = table.Column<string>(type: "text", nullable: true),
                    LegalMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    LegalOccupation = table.Column<string>(type: "text", nullable: true),
                    LegalSalutationId = table.Column<string>(type: "text", nullable: true),
                    LegalAadharNumber = table.Column<string>(type: "text", nullable: true),
                    LegalAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LegalBvEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LegalCompany = table.Column<string>(type: "text", nullable: true),
                    LegalDesignation = table.Column<string>(type: "text", nullable: true),
                    LegalEmail = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianFirstName = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianLastName = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianMiddleName = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianMobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    LocalGuardianOccupation = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianSalutationId = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianAadharNumber = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LocalGuardianBvEmployee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LocalGuardianCompany = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianDesignation = table.Column<string>(type: "text", nullable: true),
                    LocalGuardianEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicClasses",
                columns: table => new
                {
                    AcademicClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AcademicYear = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClassName = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    Group = table.Column<string>(type: "text", nullable: true),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClasses", x => x.AcademicClassId);
                    table.ForeignKey(
                        name: "FK_AcademicClasses_AcademicClassSubjects_AcademicClassSubjectId",
                        column: x => x.AcademicClassSubjectId,
                        principalTable: "AcademicClassSubjects",
                        principalColumn: "AcademicClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubjectDescr = table.Column<string>(type: "text", nullable: true),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_AcademicClassSubjects_AcademicClassSubjectId",
                        column: x => x.AcademicClassSubjectId,
                        principalTable: "AcademicClassSubjects",
                        principalColumn: "AcademicClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddress",
                columns: table => new
                {
                    StaffAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "text", nullable: true),
                    Line2 = table.Column<string>(type: "text", nullable: true),
                    Line3 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Sate = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Pincode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAddress", x => x.StaffAddressId);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffExperience",
                columns: table => new
                {
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime", nullable: true),
                    To = table.Column<DateTime>(type: "datetime", nullable: true),
                    Responsibilty = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffExperience", x => x.StaffExperienceId);
                    table.ForeignKey(
                        name: "FK_StaffExperience_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicClasses_AcademicClassSubjectId",
                table: "AcademicClasses",
                column: "AcademicClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_StaffId",
                table: "StaffAddress",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffExperience_StaffId",
                table: "StaffExperience",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademicClassSubjectId",
                table: "Subjects",
                column: "AcademicClassSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicClasses");

            migrationBuilder.DropTable(
                name: "LessonPlans");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "StaffAddress");

            migrationBuilder.DropTable(
                name: "StaffExperience");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "AcademicClassSubjects");
        }
    }
}
