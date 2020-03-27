using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class UpdateSettings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Settings",
                nullable: false,
                defaultValueSql:"GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Settings");
        }
    }
}
