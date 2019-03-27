using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluraMVC5.Models
{
    public class CategoriaDoProduto
    {
        public CategoriaDoProduto() { }

        public CategoriaDoProduto(CategoriaDoProduto categoria)
        {
            Id = categoria.Id;
            Nome = categoria.Nome;
            Descricao = categoria.Descricao;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}