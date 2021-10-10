using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class MessagingModelV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageRecipients",
                columns: table => new
                {
                    MessageRecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsRead = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRecipients", x => x.MessageRecipientId);
                });

            migrationBuilder.CreateTable(
                name: "ReminderFrequencies",
                columns: table => new
                {
                    ReminderFrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderFrequencies", x => x.ReminderFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    MessageBody = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<int>(type: "int", nullable: false),
                    ParentMessageId = table.Column<int>(type: "int", nullable: false),
                    Expirydate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsReminder = table.Column<int>(type: "int", nullable: false),
                    NextReminderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MessageRecipientId = table.Column<int>(type: "int", nullable: true),
                    ReminderFrequencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_MessageRecipients_MessageRecipientId",
                        column: x => x.MessageRecipientId,
                        principalTable: "MessageRecipients",
                        principalColumn: "MessageRecipientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_ReminderFrequencies_ReminderFrequencyId",
                        column: x => x.ReminderFrequencyId,
                        principalTable: "ReminderFrequencies",
                        principalColumn: "ReminderFrequencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageRecipientId",
                table: "Messages",
                column: "MessageRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReminderFrequencyId",
                table: "Messages",
                column: "ReminderFrequencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MessageRecipients");

            migrationBuilder.DropTable(
                name: "ReminderFrequencies");
        }
    }
}
