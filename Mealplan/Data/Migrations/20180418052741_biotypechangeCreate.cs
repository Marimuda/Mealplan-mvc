using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mealplan.Data.Migrations
{
    public partial class biotypechangeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "biodata",
                type: "int(5)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "tinyint(4)");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "biodata",
                type: "int(5)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "tinyint(4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "biodata",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(5)");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "biodata",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(5)");
        }
    }
}
