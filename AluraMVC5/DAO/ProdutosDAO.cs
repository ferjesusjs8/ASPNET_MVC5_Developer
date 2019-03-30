using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AluraMVC5.Resources;
using System.IO;
using System.Diagnostics;

namespace AluraMVC5.DAO
{
    public class ProdutosDAO
    {
        public void Adiciona(Produto produto)
        {
            using (var context = new EstoqueContext())
            {
                var categoria = CategoriasDAO.BuscaPorId(produto.CategoriaId);
                produto.Categoria = categoria;
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public IList<Produto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Produtos
                                .Include("Categoria")
                                .ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Produtos.Include("Categoria")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}