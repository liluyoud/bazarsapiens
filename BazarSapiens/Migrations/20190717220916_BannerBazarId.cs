using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class BannerBazarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Bazares",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Bazares",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Bazares",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BazarId",
                table: "Banners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_BazarId",
                table: "Banners",
                column: "BazarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Bazares_BazarId",
                table: "Banners",
                column: "BazarId",
                principalTable: "Bazares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Bazares_BazarId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_BazarId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Bazares");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Bazares");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Bazares");

            migrationBuilder.DropColumn(
                name: "BazarId",
                table: "Banners");
        }
    }
}
