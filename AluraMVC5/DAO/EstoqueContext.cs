using AluraMVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AluraMVC5.DAO
{
    public class EstoqueContext : DbContext
    {
        private static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
        public EstoqueContext() : base(conn) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CategoriaDoProduto> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}