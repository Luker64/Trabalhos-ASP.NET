using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWeb.Models;

namespace LojaWeb.DAO{
    public class CarrinhoDAO {
        private EntidadeContext context;

        public CarrinhoDAO()
        {
            context = new EntidadeContext();
        }

        public Carrinho CriaCarrinho()
        {
            Carrinho c = new Carrinho();
            c.UsuarioId = UserLogado.Id;
            c.Estado = true;
            c.PrecoFinal = 0.0;
            
            context.Carrinhos.Add(c);
            context.SaveChanges();
            return c;
        }

        public IList<Carrinho> GetCarrinhos()
        {
            return context.Carrinhos.ToList();
        }

        public bool ChecarCarrAnteriores() //Checa se o cliente já realizou pedidos anteriormente
        {
            IList<Carrinho> carrinhos = GetCarrinhos();
            foreach (var c in carrinhos)
            {
                if (c.UsuarioId == UserLogado.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public Carrinho BuscarUltimoCarrinho()
        {
            if (ChecarCarrAnteriores())
            {
                IList<Carrinho> carrinhos = (from c in context.Carrinhos where c.UsuarioId == UserLogado.Id select c).ToList();
                return carrinhos.Last();
            }
            return CriaCarrinho();
        }

        public void AdicionarProd(Produto prod, int c)
        {
            ItemCarrinhoDAO icdao = new ItemCarrinhoDAO();
            ItemCarrinho ic = icdao.CadastrarItem(prod, c);
            //ca.itemCarrinhos.Add(ic);
        }

        public Carrinho PegaCarrinho(int id)
        {
            return context.Carrinhos.FirstOrDefault(c => c.Id == id);
        }

        public void SetTotal(int Id, double tot)
        {
            Carrinho c = PegaCarrinho(Id);
            c.PrecoFinal = tot;
            context.SaveChanges();
        }

        public void SetState(int Id, bool state)
        {
            Carrinho c = PegaCarrinho(Id);
            c.Estado = state;
            context.SaveChanges();
        }
    }      
}