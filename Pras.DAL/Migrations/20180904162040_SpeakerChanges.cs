using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pras.DAL.Migrations
{
    public partial class SpeakerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Track",
                table: "Speakers",
                newName: "WorkingHours");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Speakers",
                newName: "WorkingDays");

            migrationBuilder.DropColumn(
                name: "Terms",
                table: "Speakers");

            migrationBuilder.AddColumn<float>(
                name: "Terms",
                table: "Speakers",
                nullable: false,
                defaultValue:0);

            migrationBuilder.AddColumn<bool>(
                name: "CanDirect",
                table: "Speakers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Speakers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Demo",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DemoAdvertising",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DemoVoiceOver",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industries",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Params",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Portfolio",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceCategory",
                table: "Speakers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PricePage",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Speakers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VacationEndDate",
                table: "Speakers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VacationStartDate",
                table: "Speakers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Videos",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoiceAge",
                table: "Speakers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VoiceDescription",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voices",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTypes",
                table: "Speakers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDirect",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Demo",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "DemoAdvertising",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "DemoVoiceOver",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Industries",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Params",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Portfolio",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "PriceCategory",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "PricePage",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "VacationEndDate",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "VacationStartDate",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Videos",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "VoiceAge",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "VoiceDescription",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Voices",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "WorkTypes",
                table: "Speakers");

            migrationBuilder.RenameColumn(
                name: "WorkingHours",
                table: "Speakers",
                newName: "Track");

            migrationBuilder.RenameColumn(
                name: "WorkingDays",
                table: "Speakers",
                newName: "Language");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "Speakers",
                nullable: true,
                oldClrType: typeof(float));
        }
    }
}
