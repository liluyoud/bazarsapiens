using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class Facebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Colaboradores",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Colaboradores",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Colaboradores",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Colaboradores");
        }
    }
}
