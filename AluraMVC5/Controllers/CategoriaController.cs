using AluraMVC5.DAO;
using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();

            if (!categorias.Any())
            {
                ProdutosDAO.DBInitialInsert();
                categorias = categoriasDAO.Lista();
            }

            ViewBag.Categorias = categorias;
            return View();
        }
    }
}