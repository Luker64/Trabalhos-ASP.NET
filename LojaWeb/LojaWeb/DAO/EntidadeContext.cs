using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.Entity;
using System.Configuration;

namespace LojaWeb.DAO {
    public class EntidadeContext : DbContext {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinhos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string conexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(conexao);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemCarrinho>().HasKey(ic => new
            {
                ic.IdCarrinho,
                ic.IdProduto
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}