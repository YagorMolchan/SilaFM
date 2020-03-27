using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class SettingsBlocksLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Block1Link",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block2Link",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block3Link",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block4Link",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block5Link",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block6Link",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block1Link",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block2Link",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block3Link",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block4Link",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block5Link",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block6Link",
                table: "Settings");
        }
    }
}
