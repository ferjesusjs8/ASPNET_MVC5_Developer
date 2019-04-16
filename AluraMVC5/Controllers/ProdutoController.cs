using AluraMVC5.DAO;
using AluraMVC5.Filters;
using AluraMVC5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO produtosDao = new ProdutosDAO();
            IList<Produto> produtos = produtosDao.Lista();
            if (!produtos.Any())
                return RedirectToAction("Adiciona", "Produto");

            return View(produtos);
        }

        [Route("produtos/adicionar", Name = "AdicionarProduto")]
        public ActionResult Adiciona()
        {
            CategoriasDAO categoriaDao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriaDao.Lista();

            if (!categorias.Any())
                return RedirectToAction("Adiciona", "Categoria");

            ViewBag.Produto = new Produto();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Produto produto)
        {
            if (produto.Quantidade < 1)
                ModelState.AddModelError("produto.Invalido", "Erro: Quantidade deve ser maior que zero");

            if (ModelState.IsValid)
            {
                ProdutosDAO produtosDao = new ProdutosDAO();
                produtosDao.Adiciona(produto);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                CategoriasDAO categorias = new CategoriasDAO();
                ViewBag.Produto = produto;
                ViewBag.Categorias = categorias.Lista();
                return View("Adiciona");
            }

        }

        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO produtos = new ProdutosDAO();
            var produto = produtos.BuscaPorId(id);
            return View(produto);
        }

        public ActionResult DecrementaQuantidade(int id)
        {
            ProdutosDAO produtos = new ProdutosDAO();
            var produto = produtos.BuscaPorId(id);
            produto.Quantidade--;
            produtos.Atualiza(produto);
            return Json(produto);
        }
    }
}