using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class bankseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankDescr" },
                values: new object[,]
                {
                    { 1, "State Bank of India (SBI)" },
                    { 21, "Jammu & Kashmir Bank" },
                    { 22, "Karur Vysya Bank" },
                    { 23, "Lakshmi Vilas Bank" },
                    { 24, "Nainital Bank" },
                    { 25, "RBL Bank" },
                    { 26, "South Indian Bank" },
                    { 20, "IDFC First Bank" },
                    { 27, "Tamilnad Mercantile Bank Limited" },
                    { 29, "Kotak Mahindra Bank" },
                    { 30, "Bank of India" },
                    { 31, "Canara Bank" },
                    { 32, "IndusInd Bank" },
                    { 33, "YES Bank" },
                    { 34, "Karnataka Bank" },
                    { 28, "Axis Bank" },
                    { 19, "IDBI Bank" },
                    { 18, "ICICI Bank" },
                    { 17, "HDFC Bank" },
                    { 2, "Punjab National Bank" },
                    { 3, "Bank of Baroda (With Merger of Dena Bank & Vijaya Bank)" },
                    { 4, "Canara Bank (With Merger of Syndicate Bank)" },
                    { 5, "Union Bank of India (With Merger of Andhra Bank and Corporation Bank)" },
                    { 6, "Indian Bank (With Merger of Allahabad Bank)" },
                    { 7, "Central Bank of India" },
                    { 8, "UCO Bank" },
                    { 9, "Bank of Maharashtra" },
                    { 10, "Punjab & Sindh Bank" },
                    { 11, "Bandhan Bank" },
                    { 12, "Catholic Syrian Bank" },
                    { 13, "City Union Bank" },
                    { 14, "DCB Bank" },
                    { 15, "Dhanlaxmi Bank" },
                    { 16, "Federal Bank" },
                    { 35, "Indian Overseas Bank" },
                    { 36, "Union Bank of India (Andhra Bank & Corporation Bank)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 36);
        }
    }
}
