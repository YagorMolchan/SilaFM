using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class HeaderSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoSubtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phones",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Socials",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LogoSubtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Phones",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Socials",
                table: "Settings");
        }
    }
}
