using Microsoft.EntityFrameworkCore.Migrations;

namespace Pras.DAL.Migrations
{
    public partial class LinkCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Services");
        }
    }
}
