using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class UpdateSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block1Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block1Title",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block2Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block2Title",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block3Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block3Title",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block4Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block4Title",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block5Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block5Title",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block6Subtitle",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block6Title",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block1Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block1Title",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block2Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block2Title",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block3Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block3Title",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block4Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block4Title",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block5Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block5Title",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block6Subtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Block6Title",
                table: "Settings");
        }
    }
}
