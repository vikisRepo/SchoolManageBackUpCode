using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SMS.Migrations.MysqlData
{
    public partial class TransportDetUpdateLatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "company",
            //    table: "BusesAndDrivers");

            migrationBuilder.AddColumn<string>(
     name: "company",
     table: "BusesAndDrivers",
     type: "text",
     nullable: true);

            //migrationBuilder.DropForeignKey(
            //    name: "FK_BusesAndDrivers_BusTypes_BusTypeid",
            //    table: "BusesAndDrivers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_BusesAndDrivers_NotificationSpans_NotificationSpanId",
            //    table: "BusesAndDrivers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "NotificationSpanId",
            //    table: "BusesAndDrivers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "BusTypeid",
            //    table: "BusesAndDrivers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);



            //migrationBuilder.CreateTable(
            //    name: "ClassTimeTable",
            //    columns: table => new
            //    {
            //        ClassTimeTableId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        Class = table.Column<string>(type: "text", nullable: true),
            //        Section = table.Column<string>(type: "text", nullable: true),
            //        Year = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClassTimeTable", x => x.ClassTimeTableId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PeriodDetail",
            //    columns: table => new
            //    {
            //        PeriodDetailId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        StaffId = table.Column<int>(type: "int", nullable: true),
            //        StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        SubjectID = table.Column<int>(type: "int", nullable: true),
            //        Period = table.Column<int>(type: "int", nullable: false),
            //        Day = table.Column<string>(type: "text", nullable: true),
            //        ClassTimeTableId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PeriodDetail", x => x.PeriodDetailId);
            //        table.ForeignKey(
            //            name: "FK_PeriodDetail_ClassTimeTable_ClassTimeTableId",
            //            column: x => x.ClassTimeTableId,
            //            principalTable: "ClassTimeTable",
            //            principalColumn: "ClassTimeTableId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PeriodDetail_Staffs_StaffId",
            //            column: x => x.StaffId,
            //            principalTable: "Staffs",
            //            principalColumn: "StaffId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PeriodDetail_Subjects_SubjectID",
            //            column: x => x.SubjectID,
            //            principalTable: "Subjects",
            //            principalColumn: "SubjectID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PeriodDetail_ClassTimeTableId",
            //    table: "PeriodDetail",
            //    column: "ClassTimeTableId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PeriodDetail_StaffId",
            //    table: "PeriodDetail",
            //    column: "StaffId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PeriodDetail_SubjectID",
            //    table: "PeriodDetail",
            //    column: "SubjectID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BusesAndDrivers_BusTypes_BusTypeid",
            //    table: "BusesAndDrivers",
            //    column: "BusTypeid",
            //    principalTable: "BusTypes",
            //    principalColumn: "BusTypeid",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BusesAndDrivers_NotificationSpans_NotificationSpanId",
            //    table: "BusesAndDrivers",
            //    column: "NotificationSpanId",
            //    principalTable: "NotificationSpans",
            //    principalColumn: "NotificationSpanId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusesAndDrivers_BusTypes_BusTypeid",
                table: "BusesAndDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusesAndDrivers_NotificationSpans_NotificationSpanId",
                table: "BusesAndDrivers");

            migrationBuilder.DropTable(
                name: "PeriodDetail");

            migrationBuilder.DropTable(
                name: "ClassTimeTable");

            migrationBuilder.DropColumn(
                name: "company",
                table: "BusesAndDrivers");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationSpanId",
                table: "BusesAndDrivers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusTypeid",
                table: "BusesAndDrivers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BusesAndDrivers_BusTypes_BusTypeid",
                table: "BusesAndDrivers",
                column: "BusTypeid",
                principalTable: "BusTypes",
                principalColumn: "BusTypeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusesAndDrivers_NotificationSpans_NotificationSpanId",
                table: "BusesAndDrivers",
                column: "NotificationSpanId",
                principalTable: "NotificationSpans",
                principalColumn: "NotificationSpanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
