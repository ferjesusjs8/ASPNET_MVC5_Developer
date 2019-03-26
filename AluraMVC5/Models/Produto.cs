using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluraMVC5.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}