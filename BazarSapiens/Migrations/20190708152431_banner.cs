using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conteúdo",
                table: "Banners");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Banners",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Banners");

            migrationBuilder.AddColumn<string>(
                name: "Conteúdo",
                table: "Banners",
                nullable: true);
        }
    }
}
