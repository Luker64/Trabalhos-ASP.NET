using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace LojaWeb.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Carrinho_Usuario_UsuarioId", table: "Carrinho");
            migrationBuilder.DropForeignKey(name: "FK_Produto_CategoriaProduto_CategoriaID", table: "Produto");
            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuario_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
            migrationBuilder.DropForeignKey(name: "FK_Carrinho_Usuario_UsuarioId", table: "Carrinho");
            migrationBuilder.DropForeignKey(name: "FK_Produto_CategoriaProduto_CategoriaID", table: "Produto");
            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuario_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
