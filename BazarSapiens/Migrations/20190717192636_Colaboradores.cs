using Microsoft.EntityFrameworkCore.Migrations;

namespace BazarSapiens.Migrations
{
    public partial class Colaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(maxLength: 20, nullable: true),
                    BazarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testemunhos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(maxLength: 255, nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    BazarId = table.Column<long>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testemunhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testemunhos_Bazares_BazarId",
                        column: x => x.BazarId,
                        principalTable: "Bazares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_BazarId",
                table: "Colaboradores",
                column: "BazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Testemunhos_BazarId",
                table: "Testemunhos",
                column: "BazarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Testemunhos");
        }
    }
}
