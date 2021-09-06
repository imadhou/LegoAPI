using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDebut",
                table: "EmployeConges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 2, 15, 59, 970, DateTimeKind.Local).AddTicks(6199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 0, 19, 20, 330, DateTimeKind.Local).AddTicks(9204));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDebut",
                table: "EmployeConges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 0, 19, 20, 330, DateTimeKind.Local).AddTicks(9204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 2, 15, 59, 970, DateTimeKind.Local).AddTicks(6199));
        }
    }
}
