using AluraMVC5.DAO;
using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            if (Session["message"] != null)
                ViewBag.Message = Session["message"].ToString();

            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(string login, string senha, string email)
        {
            var _context = new UsuariosDAO();
            var usuario = _context.BuscaLogin(login);
            if (usuario == null)
            {
                _context.Adiciona(new Usuario(login, senha, email));

                Session["message"] = "";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["message"] = "Usuário já existe na base de dados.";
                return RedirectToAction("Index");
            }
        }
    }
}