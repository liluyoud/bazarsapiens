using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class CategoriaBazarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BazarId",
                table: "Categorias",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_BazarId",
                table: "Categorias",
                column: "BazarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Bazares_BazarId",
                table: "Categorias",
                column: "BazarId",
                principalTable: "Bazares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Bazares_BazarId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_BazarId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "BazarId",
                table: "Categorias");
        }
    }
}
