using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class CourseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "CompletionCriterias",
                columns: table => new
                {
                    CompletionCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionCriterias", x => x.CompletionCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    CourseDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompletionCriteriaId = table.Column<int>(type: "int", nullable: true),
                    PassingScore = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.CourseDetailID);
                    table.ForeignKey(
                        name: "FK_CourseDetails_CompletionCriterias_CompletionCriteriaId",
                        column: x => x.CompletionCriteriaId,
                        principalTable: "CompletionCriterias",
                        principalColumn: "CompletionCriteriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_CompletionCriteriaId",
                table: "CourseDetails",
                column: "CompletionCriteriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "CompletionCriterias");
        }
    }
}
