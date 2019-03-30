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
                return RedirectToAction("Adiciona", "Produto");

            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Adiciona()
        {
            CategoriasDAO categoriaDao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriaDao.Lista();
            if (!categorias.Any())
                return RedirectToAction("Adiciona", "Categoria");

            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Produto produto)
        {
            ProdutosDAO produtosDao = new ProdutosDAO();
            produtosDao.Adiciona(produto);
            return RedirectToAction("Index", "Produto");
        }
    }
}