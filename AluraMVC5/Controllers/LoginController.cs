using AluraMVC5.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            UsuariosDAO _contexto = new UsuariosDAO();
            var usuario = _contexto.Busca(login, senha);
            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}