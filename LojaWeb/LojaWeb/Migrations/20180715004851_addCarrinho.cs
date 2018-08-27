using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace LojaWeb.Migrations
{
    public partial class addCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_CategoriaProduto_CategoriaID", table: "Produto");
            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<bool>(nullable: false),
                    PrecoFinal = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinho_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    IdCarrinho = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    CarrinhoId = table.Column<int>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => new { x.IdCarrinho, x.IdProduto });
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Carrinho_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_CategoriaProduto_CategoriaID",
                table: "Produto",
                column: "CategoriaID",
                principalTable: "CategoriaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_CategoriaProduto_CategoriaID", table: "Produto");
            migrationBuilder.DropTable("ItemCarrinho");
            migrationBuilder.DropTable("Carrinho");
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_CategoriaProduto_CategoriaID",
                table: "Produto",
                column: "CategoriaID",
                principalTable: "CategoriaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
