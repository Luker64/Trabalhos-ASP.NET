using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.Entity;
using System.Configuration;
using TrabalhoFerias.Models;

namespace TrabalhoFerias.DAO
{
    public class EntidadeContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<ProdutoVenda> ProdutoVendas  { get; set; }
        public DbSet<CompraPedido> CompraPedidos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(conexao);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().HasKey(e => new { e.CEP });
            modelBuilder.Entity<Funcionario>().HasKey(f => new { f.Id });
            modelBuilder.Entity<Fornecedor>().HasKey(f => new { f.Codigo });
            modelBuilder.Entity<Cliente>().HasKey(c => new { c.CPF });
            modelBuilder.Entity<Venda>().HasKey(v => new { v.Notafiscal });
            modelBuilder.Entity<Compra>().HasKey(c => new { c.NotaFiscal });
            modelBuilder.Entity<CompraPedido>().HasKey(cp => new { cp.NotaFiscal,cp.Codigo });
            modelBuilder.Entity<ProdutoVenda>().HasKey(pv => new { pv.NotaFiscal,pv.Codigo });
            modelBuilder.Entity<Despesa>().HasKey(d => new { d.Id });
            modelBuilder.Entity<Caixa>().HasKey(c => new {c.IdMovimento });
            modelBuilder.Entity<Produto>().HasKey(p => new { p.Codigo });


            base.OnModelCreating(modelBuilder);
        }
        
    }
}