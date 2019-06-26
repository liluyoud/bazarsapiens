using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    Subtitulo = table.Column<string>(maxLength: 255, nullable: false),
                    Conteúdo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bazares",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    Visualizacoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bazares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

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
                    TotalFotos = table.Column<int>(nullable: false),
                    Visualizacoes = table.Column<int>(nullable: false),
                    BazarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    BazarId = table.Column<long>(nullable: true),
                    Visualizacoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parceiros_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(maxLength: 5000, nullable: false),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    ValorLance = table.Column<decimal>(nullable: false),
                    ValorAtual = table.Column<decimal>(nullable: false),
                    QuantidadeLances = table.Column<int>(nullable: false),
                    Visualizacoes = table.Column<int>(nullable: false),
                    TotalFotos = table.Column<int>(nullable: false),
                    FotoPrincipal = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 10, nullable: false),
                    CategoriaId = table.Column<long>(nullable: true),
                    BazarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_BazarId",
                table: "Noticias",
                column: "BazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_BazarId",
                table: "Parceiros",
                column: "BazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_BazarId",
                table: "Produtos",
                column: "BazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Bazares");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
