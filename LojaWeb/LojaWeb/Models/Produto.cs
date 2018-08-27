using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Models {
    public class Produto {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public int CategoriaID { get; set; }
    }
}