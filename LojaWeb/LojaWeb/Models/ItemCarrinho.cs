using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Models
{
    public class ItemCarrinho
    {
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}