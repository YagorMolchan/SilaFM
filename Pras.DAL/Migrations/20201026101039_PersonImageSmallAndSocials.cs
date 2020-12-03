using Microsoft.EntityFrameworkCore.Migrations;

namespace Pras.DAL.Migrations
{
    public partial class PersonImageSmallAndSocials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSmall",
                table: "People",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Socials",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSmall",
                table: "People");
            migrationBuilder.DropColumn(
                name: "Socials",
                table: "People");
        }
    }
}
