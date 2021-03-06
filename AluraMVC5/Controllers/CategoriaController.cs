﻿using AluraMVC5.DAO;
using AluraMVC5.Filters;
using AluraMVC5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AluraMVC5.Controllers
{
    [AutorizacaoFilter]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();

            if (!categorias.Any())
                return RedirectToAction("Adiciona", "Categoria");

            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Adiciona() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoriaDoProduto categoria)
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            categoriasDAO.Adiciona(categoria);
            return RedirectToAction("Index", "Categoria");
        }
    }
}