using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class factorydataV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleFunction");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.CreateTable(
                name: "Bloodgroups",
                columns: table => new
                {
                    BloodgroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BloodgroupName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloodgroups", x => x.BloodgroupId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Maritalstatus",
                columns: table => new
                {
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaritalStatusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maritalstatus", x => x.MaritalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Salutations",
                columns: table => new
                {
                    SalutationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SalutationName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salutations", x => x.SalutationId);
                });

            migrationBuilder.InsertData(
                table: "Bloodgroups",
                columns: new[] { "BloodgroupId", "BloodgroupName" },
                values: new object[,]
                {
                    { 1, "(A +)" },
                    { 2, "(A -)" },
                    { 3, "(B +)" },
                    { 4, "(B -)" },
                    { 5, "(O +)" },
                    { 6, "(O -)" },
                    { 7, "(AB +)" },
                    { 8, "(AB -)" },
                    { 9, "Vice Principal" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 4, "Not willing to disclose" },
                    { 3, "Trans" },
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageDescription" },
                values: new object[,]
                {
                    { 10, "Odia" },
                    { 15, "Others" },
                    { 14, "French" },
                    { 13, "Assamese" },
                    { 12, "Punjabi" },
                    { 11, "Malayalam" },
                    { 9, "Kannada" },
                    { 2, "English" },
                    { 7, "Gujarati" },
                    { 6, "Tamil" },
                    { 5, "Telugu" },
                    { 4, "Marathi" },
                    { 3, "Bengali" },
                    { 1, "Hindi" },
                    { 8, "Urdu" }
                });

            migrationBuilder.InsertData(
                table: "Maritalstatus",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[,]
                {
                    { 5, "Single" },
                    { 4, "Divorced" },
                    { 2, "Widowed" },
                    { 1, "Married" },
                    { 3, "Separated" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "NationalityName" },
                values: new object[,]
                {
                    { 1, "Indian" },
                    { 2, "Others" },
                    { 3, "Not willing to disclose" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "ReligionId", "ReligionName" },
                values: new object[,]
                {
                    { 6, "Jains" },
                    { 1, "Hindu" },
                    { 2, "Christian" },
                    { 3, "Muslim" },
                    { 4, "Sikh" },
                    { 5, "Buddhist" },
                    { 7, "Others" },
                    { 8, "Not willing to disclose" }
                });

            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "SalutationId", "SalutationName" },
                values: new object[,]
                {
                    { 4, "Master" },
                    { 3, "Miss" },
                    { 2, "Mrs." },
                    { 1, "Mr." }
                });

            migrationBuilder.InsertData(
                table: "StaffTypes",
                columns: new[] { "StaffTypeId", "Description" },
                values: new object[,]
                {
                    { 7, "IT Technician" },
                    { 10, "Lab Staff" },
                    { 9, "Librarian" },
                    { 8, "Vice Principal" },
                    { 6, "Driver" },
                    { 11, "PET" },
                    { 4, "Co-ordinator" },
                    { 3, "Principal" },
                    { 2, "Admin" },
                    { 1, "Teacher" },
                    { 5, "Support Staff" },
                    { 12, "HOD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloodgroups");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Maritalstatus");

            migrationBuilder.DropTable(
                name: "Salutations");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "ReligionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StaffTypes",
                keyColumn: "StaffTypeId",
                keyValue: 12);

            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decription = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<string>(type: "text", nullable: true),
                    DisplayValue = table.Column<string>(type: "text", nullable: true),
                    ParentFunctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunction",
                columns: table => new
                {
                    RoleFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunction", x => x.RoleFunctionId);
                    table.ForeignKey(
                        name: "FK_RoleFunction_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFunction_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_FunctionId",
                table: "RoleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_RoleId",
                table: "RoleFunction",
                column: "RoleId");
        }
    }
}
