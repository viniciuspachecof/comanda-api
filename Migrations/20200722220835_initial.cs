using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiComanda.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "comanda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<int>(nullable: false),
                    qtde = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comanda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    observacao = table.Column<string>(nullable: true),
                    categoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comandaproduto",
                columns: table => new
                {
                    comandaId = table.Column<int>(nullable: false),
                    produtoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comandaproduto", x => new { x.produtoId, x.comandaId });
                    table.ForeignKey(
                        name: "FK_comandaproduto_comanda_comandaId",
                        column: x => x.comandaId,
                        principalTable: "comanda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comandaproduto_produto_produtoId",
                        column: x => x.produtoId,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "descricao" },
                values: new object[] { 1, "Alimento" });

            migrationBuilder.InsertData(
                table: "comanda",
                columns: new[] { "id", "numero", "qtde" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "id", "categoriaId", "nome", "observacao", "valor" },
                values: new object[] { 1, 1, "Pão", "Doce", 1.23 });

            migrationBuilder.InsertData(
                table: "comandaproduto",
                columns: new[] { "produtoId", "comandaId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_comandaproduto_comandaId",
                table: "comandaproduto",
                column: "comandaId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_categoriaId",
                table: "produto",
                column: "categoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comandaproduto");

            migrationBuilder.DropTable(
                name: "comanda");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
