using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Caixa
    {
        public int IdMovimento { get; set; }
        public double Valor { get; set; }
        public string Data { get; set; }
        public string Tipo{ get; set; }
    }
}