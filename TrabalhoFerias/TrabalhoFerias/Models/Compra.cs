using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Compra
    {
        public int NotaFiscal{ get; set; }
        public double Total { get; set; }
        public string Data { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int Codigo { get; set; }
    }
}