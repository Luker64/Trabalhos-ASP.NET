using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO {
    public class ProdutoDAO {
        private EntidadeContext context = new EntidadeContext();

        public void Adicionar(Produto produto) {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public IList<Produto> ListarProduto() {
            return context.Produtos.ToList();
        }

        public IList<Produto> ListarProdutoId(int id)
        {
            return (from p in context.Produtos where p.Id == id select p).ToList();
        }

        public Produto BuscaId(int id)
        {
            return context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar()
        {
            context.SaveChanges();
        }

        public void Remover(Produto produto)
        {
            context.Produtos.Remove(produto);
            Atualizar();
        }
    }
}