using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class CompraPedido
    {
        public int Quantidade { get; set; }
        public double ValorUnit { get; set; }
        public Compra Compra { get; set; }
        public int NotaFiscal { get; set; }
        public Produto Produto { get; set; }
        public int Codigo { get; set; }
    }
}