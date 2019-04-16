using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluraMVC5.DAO
{
    public class UsuariosDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new EstoqueContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public Usuario BuscaLogin(string login)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.FirstOrDefault(user => user.Login == login);
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}