using LojaWeb.DAO;
using LojaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adicionar(Usuario usuario) {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Inserir(usuario);
            return View();
        }

        public ActionResult Busca()
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> usuarios = dao.ListarUsuarios();
            ViewBag.usuarios = usuarios;
            return View();
        }

        public ActionResult Editar(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> user = dao.BuscarId(id);
            ViewBag.users = user;
            return View();
        }

        public ActionResult Atualizar(Usuario usuario)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario Uvelho = dao.Buscar1Id(usuario.Id);
            Uvelho.Nome = usuario.Nome;
            Uvelho.Senha = usuario.Senha; 
            dao.Atualizar();
            return View();
        }

        public ActionResult Remover(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario user = dao.Buscar1Id(id);
            dao.Remover(user);
            return View();
        }
    }
}