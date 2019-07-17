using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class OrdemBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "Banners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "Banners");
        }
    }
}
