using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ItemCarrinhoDAO
    {
        private EntidadeContext context;
        public ItemCarrinhoDAO()
        {
            context = new EntidadeContext();
        }

        public ItemCarrinho CadastrarItem(Produto prod, int cId)
        {
            ItemCarrinho ic = new ItemCarrinho();
            ic.IdCarrinho = cId;
            ic.IdProduto = prod.Id;
            ic.Preco = prod.Preco;
            ic.Quantidade = 1;
            context.ItemCarrinhos.Add(ic);
            context.SaveChanges();
            return ic;
        }

        public IList<ItemCarrinho> ListarItensPorId(int id)//Listar pelo Id do Carrinho
        {
            return (from ic in context.ItemCarrinhos where ic.IdCarrinho == id select ic).ToList();
        }

        public ItemCarrinho BuscarPorIdCarProd(int idProd, int idCarr)
        {
            return context.ItemCarrinhos.FirstOrDefault(ic => ic.IdCarrinho == idCarr && ic.IdProduto == idProd);
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Remover(ItemCarrinho ic)
        {
            context.ItemCarrinhos.Remove(ic);
            Salvar();
        }
    }
}