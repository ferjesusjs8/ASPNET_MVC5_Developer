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

        public static void DBInitialInsert()
        {
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\", "*.json");
            List<Usuario> usuarios = LeitorJson<Usuario>.LerJson(files[2]);
            List<CategoriaDoProduto> categorias = LeitorJson<CategoriaDoProduto>.LerJson(files[0]);
            List<Produto> produtos = LeitorJson<Produto>.LerJson(files[1]);

            using (var contexto = new EstoqueContext())
            {
                usuarios.ForEach(user => contexto.Usuarios.Add(user));
                contexto.SaveChanges();
                categorias.ForEach(category => contexto.Categorias.Add(category));
                contexto.SaveChanges();
                produtos.ForEach(product =>
                    {
                        CategoriaDoProduto categoria = CategoriasDAO.BuscaPorId(product.CategoriaId.Value);
                        if (categoria != null)
                            product.Categoria = new CategoriaDoProduto(categoria);
                        contexto.Produtos.Add(product);
                    });
                contexto.SaveChanges();
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