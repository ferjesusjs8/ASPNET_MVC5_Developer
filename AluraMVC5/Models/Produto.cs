using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluraMVC5.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório."), StringLength(20, ErrorMessage = "Nome do Produto não pode ultrapassar 20 caracteres.")]
        public string Nome { get; set; }

        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}