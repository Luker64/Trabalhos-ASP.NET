using LojaWeb.DAO;
using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class CategoriaProdutoController : Controller
    {
        // GET: CategoriaProduto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormCatProd() {
            return View();
        }

        public ActionResult Adicionar(CategoriaProduto catproduto) {
            CategoriaProdutoDAO dao = new CategoriaProdutoDAO();
            dao.Adicionar(catproduto);
            return View();
        }

        public ActionResult Buscar()
        {
            CategoriaProdutoDAO dao = new CategoriaProdutoDAO();
            IList<CategoriaProduto> categorias = dao.ListarCategorias();
            ViewBag.categorias = categorias;
            return View();
        }

        public ActionResult Editar(int id)
        {
            CategoriaProdutoDAO dao = new CategoriaProdutoDAO();
            IList<CategoriaProduto> catprods = dao.ListarCategoriasId(id);
            ViewBag.catprods = catprods;
            return View();
        }

        public ActionResult Atualizar(CategoriaProduto catproduto)
        {
            CategoriaProdutoDAO dao = new CategoriaProdutoDAO();
            CategoriaProduto Vcp = dao.BuscarId(catproduto.Id);
            Vcp.Nome = catproduto.Nome;
            Vcp.Descricao = catproduto.Descricao;
            dao.Atualizar();
            return View();
        }

        public ActionResult Remover(int id)
        {
            CategoriaProdutoDAO dao = new CategoriaProdutoDAO();
            CategoriaProduto cp = dao.BuscarId(id);
            dao.Remover(cp);
            return RedirectToAction("Buscar");
        }
    }
}