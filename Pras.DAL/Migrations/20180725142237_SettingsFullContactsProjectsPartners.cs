using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class SettingsFullContactsProjectsPartners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullContacts",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partners",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Projects",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullContacts",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Partners",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Projects",
                table: "Settings");
        }
    }
}
