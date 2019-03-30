using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluraMVC5.DAO
{
    public class CategoriasDAO
    {
        public void Adiciona(CategoriaDoProduto categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<CategoriaDoProduto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Categorias.ToList();
            }
        }

        public static CategoriaDoProduto BuscaPorId(int? id)
        {
            if (id.HasValue)
                using (var contexto = new EstoqueContext())
                {
                    return contexto.Categorias.Find(id);
                }
            else
                throw new ArgumentException("Id Inválido para categoria.");
        }

        public void Atualiza(CategoriaDoProduto categoria)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}