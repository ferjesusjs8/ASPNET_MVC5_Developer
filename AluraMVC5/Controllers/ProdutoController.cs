using AluraMVC5.DAO;
using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO produtosDao = new ProdutosDAO();
            IList<Produto> produtos = produtosDao.Lista();
            if (!produtos.Any())
            {
                produtosDao.DBInitialInsert();
                produtos = produtosDao.Lista();
            }

            ViewBag.Produtos = produtos;
            return View();
        }
    }
}