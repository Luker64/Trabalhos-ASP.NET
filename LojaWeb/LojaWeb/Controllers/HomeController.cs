using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    // Um controller é uma classe que sera encarregada do controle da aplicação,
    // no padrão MVC ela sempre se encontra em uma pasta especifica e metodos actions sempre
    // vão retornar um action result referente.
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}