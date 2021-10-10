using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.MysqlData
{
    public partial class MessagingModelV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "MessageRecipients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AccountId",
                table: "Messages",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageRecipients_AccountId",
                table: "MessageRecipients",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageRecipients_Accounts_AccountId",
                table: "MessageRecipients",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageRecipients_Accounts_AccountId",
                table: "MessageRecipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AccountId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_MessageRecipients_AccountId",
                table: "MessageRecipients");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "MessageRecipients");
        }
    }
}
