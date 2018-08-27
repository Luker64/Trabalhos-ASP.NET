using LojaWeb.DAO;
using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormProd() {
            return View();
        }

        public ActionResult Adicionar(Produto produto) {
            ProdutoDAO dao = new ProdutoDAO();
            dao.Adicionar(produto);
            return View();
        }

        public ActionResult Buscar()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> produtos = dao.ListarProduto();
            ViewBag.produtos = produtos;
            return View();
        }

        public ActionResult Editar(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList <Produto> prods = dao.ListarProdutoId(id);
            ViewBag.prods = prods;
            return View();
        }

        public ActionResult Atualizar(Produto produto)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto Vprod = dao.BuscaId(produto.Id);
            Vprod.Nome = produto.Nome;
            Vprod.Descricao = produto.Descricao;
            Vprod.Preco = produto.Preco;
            Vprod.Quantidade = produto.Quantidade;
            Vprod.CategoriaID = produto.CategoriaID;
            dao.Atualizar();
            return View();
        }

        public ActionResult Remover(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto prod = dao.BuscaId(id);
            dao.Remover(prod);
            return RedirectToAction("Buscar");
        }
    }
}