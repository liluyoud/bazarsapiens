using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class LogoBazar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logotipo",
                table: "Bazares",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logotipo",
                table: "Bazares");
        }
    }
}
