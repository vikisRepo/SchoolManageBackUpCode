using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    public partial class InitialApiCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeementStatuses",
                columns: table => new
                {
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeementStatuses", x => x.EmployeementStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentFunctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguagesId);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "StaffTypes",
                columns: table => new
                {
                    StaffTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTypes", x => x.StaffTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StaffUserCreds",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffUserCreds", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserCreds",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserCreds", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunctions",
                columns: table => new
                {
                    RoleFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunctions", x => x.RoleFunctionId);
                    table.ForeignKey(
                        name: "FK_RoleFunctions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFunctions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalutationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marritalsatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    MotherTongue = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIfscCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffTypeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficialEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESINumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPFNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingTo = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveId = table.Column<int>(type: "int", nullable: false),
                    UANNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false),
                    StaffUserCredStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_StaffUserCreds_StaffUserCredStaffId",
                        column: x => x.StaffUserCredStaffId,
                        principalTable: "StaffUserCreds",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    FathersSalutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    MothersSalutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    MothersAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianSalutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGaurdianAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LocalGaurdianAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianSalutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianAnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    LegalGaurdianAadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalGaurdianSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TransferCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BirthCertificate = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Passport = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Aadhar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RationCard = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StudentVisa = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudentUserCreds_StudentUserCredStudentId",
                        column: x => x.StudentUserCredStudentId,
                        principalTable: "StudentUserCreds",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressStaff",
                columns: table => new
                {
                    CurrentAddressAddressId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressStaff", x => new { x.CurrentAddressAddressId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_AddressStaff_Addresses_CurrentAddressAddressId",
                        column: x => x.CurrentAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressStaff_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffExperiences",
                columns: table => new
                {
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responsibilty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffExperiences", x => x.StaffExperienceId);
                    table.ForeignKey(
                        name: "FK_StaffExperiences_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressStaff_StaffId",
                table: "AddressStaff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunctions_FunctionId",
                table: "RoleFunctions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunctions_RoleId",
                table: "RoleFunctions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffExperiences_StaffId",
                table: "StaffExperiences",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DesignationId",
                table: "Staffs",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffUserCredStaffId",
                table: "Staffs",
                column: "StaffUserCredStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressStaff");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeementStatuses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "RoleFunctions");

            migrationBuilder.DropTable(
                name: "StaffExperiences");

            migrationBuilder.DropTable(
                name: "StaffTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "StudentUserCreds");

            migrationBuilder.DropTable(
                name: "StaffUserCreds");
        }
    }
}
