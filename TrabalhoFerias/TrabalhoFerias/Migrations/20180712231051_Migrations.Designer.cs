using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TrabalhoFerias.DAO;

namespace TrabalhoFerias.Migrations
{
    [DbContext(typeof(EntidadeContext))]
    [Migration("20180712231051_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrabalhoFerias.Models.Caixa", b =>
                {
                    b.Property<int>("IdMovimento")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<string>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("IdMovimento");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Cliente", b =>
                {
                    b.Property<int>("CPF")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Celular");

                    b.Property<string>("CompEnd");

                    b.Property<string>("Email");

                    b.Property<int?>("EnderecoCEP");

                    b.Property<string>("Nome");

                    b.Property<int>("NumEnd");

                    b.Property<string>("RG");

                    b.Property<int>("Telefone");

                    b.HasKey("CPF");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Compra", b =>
                {
                    b.Property<int>("NotaFiscal")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<string>("Data");

                    b.Property<double>("Total");

                    b.HasKey("NotaFiscal");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.CompraPedido", b =>
                {
                    b.Property<int>("NotaFiscal");

                    b.Property<int>("Codigo");

                    b.Property<int?>("ProdutoCodigo");

                    b.Property<int>("Quantidade");

                    b.Property<double>("ValorUnit");

                    b.HasKey("NotaFiscal", "Codigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("IdMovimento");

                    b.Property<string>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Endereco", b =>
                {
                    b.Property<int>("CEP")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("End");

                    b.Property<string>("UF");

                    b.HasKey("CEP");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Fornecedor", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CNPJ");

                    b.Property<int>("CompEnd");

                    b.Property<string>("Contato");

                    b.Property<int?>("EnderecoCEP");

                    b.Property<int>("NumEnd");

                    b.Property<int>("Telefone");

                    b.HasKey("Codigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompEnd");

                    b.Property<int?>("EnderecoCEP");

                    b.Property<string>("Nome");

                    b.Property<int>("NumEnd");

                    b.Property<string>("Sobre");

                    b.Property<int>("Telefone");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Produto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("Codigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.ProdutoVenda", b =>
                {
                    b.Property<int>("NotaFiscal");

                    b.Property<int>("Codigo");

                    b.Property<int?>("ProdutoCodigo");

                    b.Property<int>("Quantidade");

                    b.Property<double>("ValorUnit");

                    b.HasKey("NotaFiscal", "Codigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Venda", b =>
                {
                    b.Property<int>("Notafiscal")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CPF");

                    b.Property<string>("Data");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("Id");

                    b.Property<int>("IdMovimento");

                    b.Property<double>("Total");

                    b.HasKey("Notafiscal");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Cliente", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoCEP");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Compra", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Fornecedor")
                        .WithMany()
                        .HasForeignKey("Codigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.CompraPedido", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Compra")
                        .WithMany()
                        .HasForeignKey("NotaFiscal");

                    b.HasOne("TrabalhoFerias.Models.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoCodigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Despesa", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("TrabalhoFerias.Models.Caixa")
                        .WithMany()
                        .HasForeignKey("IdMovimento");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Fornecedor", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoCEP");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Funcionario", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoCEP");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.ProdutoVenda", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Venda")
                        .WithMany()
                        .HasForeignKey("NotaFiscal");

                    b.HasOne("TrabalhoFerias.Models.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoCodigo");
                });

            modelBuilder.Entity("TrabalhoFerias.Models.Venda", b =>
                {
                    b.HasOne("TrabalhoFerias.Models.Cliente")
                        .WithMany()
                        .HasForeignKey("CPF");

                    b.HasOne("TrabalhoFerias.Models.Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("TrabalhoFerias.Models.Caixa")
                        .WithMany()
                        .HasForeignKey("IdMovimento");
                });
        }
    }
}
