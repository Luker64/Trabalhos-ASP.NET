using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace TrabalhoFerias.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    IdMovimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.IdMovimento);
                });
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    CEP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.CEP);
                });
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigo);
                });
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CPF = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Celular = table.Column<int>(nullable: false),
                    CompEnd = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    NumEnd = table.Column<int>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_NumEnd",
                        column: x => x.NumEnd,
                        principalTable: "Endereco",
                        principalColumn: "CEP",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<int>(nullable: false),
                    CompEnd = table.Column<int>(nullable: false),
                    Contato = table.Column<string>(nullable: true),
                    NumEnd = table.Column<int>(nullable: true),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Endereco_NumEnd",
                        column: x => x.NumEnd,
                        principalTable: "Endereco",
                        principalColumn: "CEP",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompEnd = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NumEnd = table.Column<int>(nullable: true),
                    Sobre = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_NumEnd",
                        column: x => x.NumEnd,
                        principalTable: "Endereco",
                        principalColumn: "CEP",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    NotaFiscal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.NotaFiscal);
                    table.ForeignKey(
                        name: "FK_Compra_Fornecedor_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Fornecedor",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: true),
                    IdMovimento = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_Funcionario_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_Caixa_IdMovimento",
                        column: x => x.IdMovimento,
                        principalTable: "Caixa",
                        principalColumn: "IdMovimento",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Notafiscal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: true),
                    IdMovimento = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Notafiscal);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_CPF",
                        column: x => x.CPF,
                        principalTable: "Cliente",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Funcionario_Id",
                        column: x => x.Id,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Caixa_IdMovimento",
                        column: x => x.IdMovimento,
                        principalTable: "Caixa",
                        principalColumn: "IdMovimento",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "CompraPedido",
                columns: table => new
                {
                    NotaFiscal = table.Column<int>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    ProdutoCodigo = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorUnit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraPedido", x => new { x.NotaFiscal, x.Codigo });
                    table.ForeignKey(
                        name: "FK_CompraPedido_Compra_NotaFiscal",
                        column: x => x.NotaFiscal,
                        principalTable: "Compra",
                        principalColumn: "NotaFiscal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraPedido_Produto_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Produto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ProdutoVenda",
                columns: table => new
                {
                    NotaFiscal = table.Column<int>(nullable: false),
                    Codigo = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorUnit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVenda", x => new { x.NotaFiscal, x.Codigo });
                    table.ForeignKey(
                        name: "FK_ProdutoVenda_Venda_NotaFiscal",
                        column: x => x.NotaFiscal,
                        principalTable: "Venda",
                        principalColumn: "Notafiscal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoVenda_Produto_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Produto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("CompraPedido");
            migrationBuilder.DropTable("Despesa");
            migrationBuilder.DropTable("ProdutoVenda");
            migrationBuilder.DropTable("Compra");
            migrationBuilder.DropTable("Venda");
            migrationBuilder.DropTable("Produto");
            migrationBuilder.DropTable("Fornecedor");
            migrationBuilder.DropTable("Cliente");
            migrationBuilder.DropTable("Funcionario");
            migrationBuilder.DropTable("Caixa");
            migrationBuilder.DropTable("Endereco");
        }
    }
}
