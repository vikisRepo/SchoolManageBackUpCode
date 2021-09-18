using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class designationseeddatafornow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "DesignationName" },
                values: new object[,]
                {
                    { 1, " Teacher" },
                    { 2, " Co-ordinator" },
                    { 3, " HOD" },
                    { 4, " Non-Teaching" },
                    { 5, " Office Associate" },
                    { 6, " Finance Associate" },
                    { 7, " Principal" },
                    { 8, " Librarian" },
                    { 9, " Vice Principal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 9);
        }
    }
}
