using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations.Data
{
    public partial class StudentV61_removedFilemanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aadhar",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthCertificate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RationCard",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentVisa",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TransferCertificate",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Aadhar",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BirthCertificate",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Passport",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePic",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RationCard",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "StudentVisa",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "TransferCertificate",
                table: "Students",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
