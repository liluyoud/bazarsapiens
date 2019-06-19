using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class Noticias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visualizacoes",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Parceiros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Visualizacoes",
                table: "Parceiros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visualizacoes",
                table: "Bazares",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Autor = table.Column<string>(maxLength: 100, nullable: false),
                    FotoPrincipal = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Visualizacoes = table.Column<int>(nullable: false),
                    BazarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_BazarId",
                table: "Noticias",
                column: "BazarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropColumn(
                name: "Visualizacoes",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "Visualizacoes",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "Visualizacoes",
                table: "Bazares");
        }
    }
}
