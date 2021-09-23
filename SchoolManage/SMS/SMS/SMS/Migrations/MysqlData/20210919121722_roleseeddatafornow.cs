using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class roleseeddatafornow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decription = table.Column<string>(type: "text", nullable: true),
                    DisplayValue = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<string>(type: "text", nullable: true),
                    ParentFunctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunction",
                columns: table => new
                {
                    RoleFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "cityDescr",
                value: "Chennai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "cityDescr",
                value: "Coimbatore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "cityDescr",
                value: "Madurai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4,
                column: "cityDescr",
                value: "Tiruchirappa");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5,
                column: "cityDescr",
                value: "Salem");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6,
                column: "cityDescr",
                value: "Tirunelveli");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7,
                column: "cityDescr",
                value: "Tiruppur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8,
                column: "cityDescr",
                value: "Vellore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9,
                column: "cityDescr",
                value: "Erode");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10,
                column: "cityDescr",
                value: "Thoothukkudi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11,
                column: "cityDescr",
                value: "Dindigul");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12,
                column: "cityDescr",
                value: "Thanjavur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13,
                column: "cityDescr",
                value: "Ranipet");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14,
                column: "cityDescr",
                value: "Sivakasi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15,
                column: "cityDescr",
                value: "Karur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16,
                column: "cityDescr",
                value: "Udhagamandal");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17,
                column: "cityDescr",
                value: "Hosur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18,
                column: "cityDescr",
                value: "Nagercoil");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19,
                column: "cityDescr",
                value: "Kanchipuram");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20,
                column: "cityDescr",
                value: "Kumarapalaya");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21,
                column: "cityDescr",
                value: "Karaikkudi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22,
                column: "cityDescr",
                value: "Neyveli");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23,
                column: "cityDescr",
                value: "Cuddalore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24,
                column: "cityDescr",
                value: "Kumbakonam");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 25,
                column: "cityDescr",
                value: "Tiruvannamal");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 26,
                column: "cityDescr",
                value: "Pollachi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 27,
                column: "cityDescr",
                value: "Rajapalayam");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 28,
                column: "cityDescr",
                value: "Gudiyatham");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 29,
                column: "cityDescr",
                value: "Pudukkottai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 30,
                column: "cityDescr",
                value: "Vaniyambadi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 31,
                column: "cityDescr",
                value: "Ambur");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "DepartmentName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "DepartmentName",
                value: "Finance");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "DepartmentName",
                value: "Library");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "DepartmentName",
                value: "IT");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                column: "DepartmentName",
                value: "Non Teaching");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6,
                column: "DepartmentName",
                value: "English");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7,
                column: "DepartmentName",
                value: "Tamil");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8,
                column: "DepartmentName",
                value: "Maths");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 9,
                column: "DepartmentName",
                value: "Science");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 10,
                column: "DepartmentName",
                value: "Social Studies");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 11,
                column: "DepartmentName",
                value: "Hindi");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 12,
                column: "DepartmentName",
                value: "Commerce");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 13,
                column: "DepartmentName",
                value: "Economics");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 14,
                column: "DepartmentName",
                value: "Accounts");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 15,
                column: "DepartmentName",
                value: "PET");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1,
                column: "DesignationName",
                value: "Teacher");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2,
                column: "DesignationName",
                value: "Co-ordinator");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                column: "DesignationName",
                value: "HOD");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "DesignationName",
                value: "Non-Teaching");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5,
                column: "DesignationName",
                value: "Office Associate");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 6,
                column: "DesignationName",
                value: "Finance Associate");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 7,
                column: "DesignationName",
                value: "Principal");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 8,
                column: "DesignationName",
                value: "Librarian");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 9,
                column: "DesignationName",
                value: "Vice Principal");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 1,
                column: "Description",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 2,
                column: "Description",
                value: "In active");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 3,
                column: "Description",
                value: "Terminated");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 4,
                column: "Description",
                value: "In Leave");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description" },
                values: new object[,]
                {
                    { 6, " Inventory Admin" },
                    { 5, " Teacher" },
                    { 4, " Student" },
                    { 3, " Finance Admin" },
                    { 2, " Admin" },
                    { 7, " Library Admin" },
                    { 1, " Super Admin" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleFunction");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "cityDescr",
                value: " Chennai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "cityDescr",
                value: " Coimbatore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "cityDescr",
                value: " Madurai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4,
                column: "cityDescr",
                value: " Tiruchirappa");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5,
                column: "cityDescr",
                value: " Salem");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6,
                column: "cityDescr",
                value: " Tirunelveli");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7,
                column: "cityDescr",
                value: " Tiruppur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8,
                column: "cityDescr",
                value: " Vellore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9,
                column: "cityDescr",
                value: " Erode");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10,
                column: "cityDescr",
                value: " Thoothukkudi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11,
                column: "cityDescr",
                value: " Dindigul");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12,
                column: "cityDescr",
                value: " Thanjavur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13,
                column: "cityDescr",
                value: " Ranipet");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14,
                column: "cityDescr",
                value: " Sivakasi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15,
                column: "cityDescr",
                value: " Karur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16,
                column: "cityDescr",
                value: " Udhagamandal");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17,
                column: "cityDescr",
                value: " Hosur");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18,
                column: "cityDescr",
                value: " Nagercoil");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19,
                column: "cityDescr",
                value: " Kanchipuram");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20,
                column: "cityDescr",
                value: " Kumarapalaya");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21,
                column: "cityDescr",
                value: " Karaikkudi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22,
                column: "cityDescr",
                value: " Neyveli");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23,
                column: "cityDescr",
                value: " Cuddalore");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24,
                column: "cityDescr",
                value: " Kumbakonam");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 25,
                column: "cityDescr",
                value: " Tiruvannamal");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 26,
                column: "cityDescr",
                value: " Pollachi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 27,
                column: "cityDescr",
                value: " Rajapalayam");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 28,
                column: "cityDescr",
                value: " Gudiyatham");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 29,
                column: "cityDescr",
                value: " Pudukkottai");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 30,
                column: "cityDescr",
                value: " Vaniyambadi");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 31,
                column: "cityDescr",
                value: " Ambur");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "DepartmentName",
                value: " Admin");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "DepartmentName",
                value: " Finance");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "DepartmentName",
                value: " Library");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "DepartmentName",
                value: " IT");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                column: "DepartmentName",
                value: " Non Teaching");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6,
                column: "DepartmentName",
                value: " English");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7,
                column: "DepartmentName",
                value: " Tamil");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8,
                column: "DepartmentName",
                value: " Maths");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 9,
                column: "DepartmentName",
                value: " Science");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 10,
                column: "DepartmentName",
                value: " Social Studies");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 11,
                column: "DepartmentName",
                value: " Hindi");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 12,
                column: "DepartmentName",
                value: " Commerce");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 13,
                column: "DepartmentName",
                value: " Economics");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 14,
                column: "DepartmentName",
                value: " Accounts");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 15,
                column: "DepartmentName",
                value: " PET");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1,
                column: "DesignationName",
                value: " Teacher");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2,
                column: "DesignationName",
                value: " Co-ordinator");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                column: "DesignationName",
                value: " HOD");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "DesignationName",
                value: " Non-Teaching");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5,
                column: "DesignationName",
                value: " Office Associate");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 6,
                column: "DesignationName",
                value: " Finance Associate");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 7,
                column: "DesignationName",
                value: " Principal");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 8,
                column: "DesignationName",
                value: " Librarian");

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 9,
                column: "DesignationName",
                value: " Vice Principal");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 1,
                column: "Description",
                value: " Active");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 2,
                column: "Description",
                value: " In active");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 3,
                column: "Description",
                value: " Terminated");

            migrationBuilder.UpdateData(
                table: "EmployeementStatuses",
                keyColumn: "EmployeementStatusId",
                keyValue: 4,
                column: "Description",
                value: " In Leave");
        }
    }
}
