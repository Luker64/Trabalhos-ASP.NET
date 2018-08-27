using LojaWeb.DAO;
using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() //Apenas Tela de Login
        {
            return View();
        }

        public ActionResult Escolher(Usuario user) //Procura se o User ja esta logado, senão pede as infos e Redireciona para Carrinho se estiver certo
        {
            UsuarioDAO udao = new UsuarioDAO();
            if((user.Nome == null) && (user.Senha == null))
            {
                user.Id = UserLogado.Id;
                user.Nome = UserLogado.Nome;
                user.Senha = UserLogado.Senha;
            }
            bool b = udao.Login(user);
            if (b)
            {
                return RedirectToAction("Carrinho");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Carrinho() //Lista os Produtos para o user escolhar qual deseja colocar no carrinho
        {
            ProdutoDAO pdao = new ProdutoDAO();
            IList<Produto> prods = pdao.ListarProduto();
            ViewBag.produts = prods;
            return View();
        }

        public ActionResult Adicionar(int id) //Adiciona ao Carrinho o item desejado pelo user
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            ProdutoDAO pdao = new ProdutoDAO();
            ItemCarrinhoDAO icdao = new ItemCarrinhoDAO();
            Carrinho c = dao.BuscarUltimoCarrinho();
            if(c.Id != 0)//se retornar algum carrinho
            {
                if(c.Estado)//ESTADO TRUE = ABERTO
                {

                    if (icdao.BuscarPorIdCarProd(id,c.Id) == null)
                    {
                        dao.AdicionarProd(pdao.BuscaId(id), c.Id);
                        return RedirectToAction("ConfirmCarrinho");
                    }
                    return RedirectToAction("ConfirmCarrinho");
                }
                else
                {
                    c = dao.CriaCarrinho();
                    dao.AdicionarProd(pdao.BuscaId(id), c.Id);
                    return RedirectToAction("ConfirmCarrinho");
                }
            }
            else
            {
                c = dao.CriaCarrinho();
                dao.AdicionarProd(pdao.BuscaId(id), c.Id);
                return RedirectToAction("ConfirmCarrinho");
            }    
        }

        public ActionResult ConfirmCarrinho()
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            ItemCarrinhoDAO icdao = new ItemCarrinhoDAO();
            ProdutoDAO pdao = new ProdutoDAO();
            Carrinho c = dao.BuscarUltimoCarrinho();
            IList<ItemCarrinho> itens = icdao.ListarItensPorId(c.Id);
            ViewBag.ItensCarrinhos = itens;
            ViewBag.ProdutosCarrinho = pdao.ListarProduto();
            double tot = 0;
            foreach(var i in itens)
            {
                Produto p = pdao.BuscaId(i.IdProduto);
                i.Preco = i.Quantidade * p.Preco;
                tot = tot + i.Preco;
            }
            dao.SetTotal(c.Id, tot);
            ViewBag.Total = tot;
            ViewBag.CarrinhoId = c.Id;
            
            return View();
        }

        public ActionResult Confirm()
        {
            return RedirectToAction("ConfirmCarrinho");
        }

        public ActionResult MudarQtd(int Qtd, int IdProd, int IdCar)
        {
            ItemCarrinhoDAO dao = new ItemCarrinhoDAO();
            ItemCarrinho ic = dao.BuscarPorIdCarProd(IdProd, IdCar);
            ic.Quantidade = Qtd;
            dao.Salvar();
            return RedirectToAction("ConfirmCarrinho");
        }

        public ActionResult RemoverItem(int idProd, int idCar)
        {
            ItemCarrinhoDAO dao = new ItemCarrinhoDAO();
            ItemCarrinho ic = dao.BuscarPorIdCarProd(idProd, idCar);
            dao.Remover(ic);
            return RedirectToAction("ConfirmCarrinho");
        }

        public ActionResult Finalizar(int Id, double preco)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.SetState(Id, false);
            ViewBag.Preco = preco;
            return View();
        }
    }
}