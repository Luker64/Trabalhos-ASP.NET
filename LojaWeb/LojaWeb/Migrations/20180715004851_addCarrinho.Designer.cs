using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using LojaWeb.DAO;

namespace LojaWeb.Migrations
{
    [DbContext(typeof(EntidadeContext))]
    [Migration("20180715004851_addCarrinho")]
    partial class addCarrinho
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaWeb.Models.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Estado");

                    b.Property<double>("PrecoFinal");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("LojaWeb.Models.CategoriaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("LojaWeb.Models.ItemCarrinho", b =>
                {
                    b.Property<int>("IdCarrinho");

                    b.Property<int>("IdProduto");

                    b.Property<int?>("CarrinhoId");

                    b.Property<double>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("IdCarrinho", "IdProduto");
                });

            modelBuilder.Entity("LojaWeb.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaID");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<float>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("LojaWeb.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("LojaWeb.Models.Carrinho", b =>
                {
                    b.HasOne("LojaWeb.Models.Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("LojaWeb.Models.ItemCarrinho", b =>
                {
                    b.HasOne("LojaWeb.Models.Carrinho")
                        .WithMany()
                        .HasForeignKey("CarrinhoId");
                });

            modelBuilder.Entity("LojaWeb.Models.Produto", b =>
                {
                    b.HasOne("LojaWeb.Models.CategoriaProduto")
                        .WithMany()
                        .HasForeignKey("CategoriaID");
                });
        }
    }
}
