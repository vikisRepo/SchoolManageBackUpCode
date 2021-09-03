using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class InitialMigrationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicClasses",
                columns: table => new
                {
                    AcademicClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClasses", x => x.AcademicClassId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicClassSubjects",
                columns: table => new
                {
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicClassSubjects", x => x.AcademicClassSubjectId);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    CourseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingScore = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.CourseDetailId);
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
                name: "LessonPlans",
                columns: table => new
                {
                    LessonPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonPlanCheckDigi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicClassId = table.Column<int>(type: "int", nullable: false),
                    AcademicClassSubjectId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    classWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    games = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concept = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.LessonPlanId);
                });

            migrationBuilder.CreateTable(
                name: "MyAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAttachments", x => x.Id);
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
                name: "StaffeLetters",
                columns: table => new
                {
                    StaffeLetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffeLetters", x => x.StaffeLetterId);
                });

            migrationBuilder.CreateTable(
                name: "StaffFeedbacks",
                columns: table => new
                {
                    StaffFeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBackType = table.Column<int>(type: "int", nullable: false),
                    FeedBackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffFeedbacks", x => x.StaffFeedbackID);
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
                    StaffAddressId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffTypeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficialEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Esinumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epfnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingTo = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveId = table.Column<int>(type: "int", nullable: false),
                    Uannumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
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
                name: "StudentCourseDetails",
                columns: table => new
                {
                    StudentCourseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentCourseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseDetails", x => x.StudentCourseDetailId);
                });

            migrationBuilder.CreateTable(
                name: "StudentFeedbacks",
                columns: table => new
                {
                    StudentFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feedbacktitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFeedbacks", x => x.StudentFeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserCred",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserCred", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectDescr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddress",
                columns: table => new
                {
                    StaffAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_StaffAddress", x => x.StaffAddressId);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Staffs_StaffId",
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
                    StudentAddressId = table.Column<int>(type: "int", nullable: false),
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
                    FatherDetailsDependentsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Dependents_FatherDetailsDependentsId",
                        column: x => x.FatherDetailsDependentsId,
                        principalTable: "Dependents",
                        principalColumn: "DependentsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudentUserCred_StudentUserCredStudentId",
                        column: x => x.StudentUserCredStudentId,
                        principalTable: "StudentUserCred",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    StudentAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Addresses", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_StaffId",
                table: "ApplicationUsers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_StaffId",
                table: "StaffAddress",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffExperiences_StaffId",
                table: "StaffExperiences",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FatherDetailsDependentsId",
                table: "Students",
                column: "FatherDetailsDependentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentUserCredStudentId",
                table: "Students",
                column: "StudentUserCredStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicClasses");

            migrationBuilder.DropTable(
                name: "AcademicClassSubjects");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeementStatuses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "LessonPlans");

            migrationBuilder.DropTable(
                name: "MyAttachments");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "StaffAddress");

            migrationBuilder.DropTable(
                name: "StaffeLetters");

            migrationBuilder.DropTable(
                name: "StaffExperiences");

            migrationBuilder.DropTable(
                name: "StaffFeedbacks");

            migrationBuilder.DropTable(
                name: "StaffTypes");

            migrationBuilder.DropTable(
                name: "StudentCourseDetails");

            migrationBuilder.DropTable(
                name: "StudentFeedbacks");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "StudentUserCred");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
