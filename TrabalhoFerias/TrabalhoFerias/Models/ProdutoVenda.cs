using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class ProdutoVenda
    {
        public int Quantidade { get; set; }
        public double ValorUnit { get; set; }
        public Venda Venda { get; set; }
        public int NotaFiscal { get; set; }
        public Produto Produto { get; set; }
        public int Codigo { get; set; }
    }
}