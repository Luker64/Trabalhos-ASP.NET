using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Venda
    {
        public int Notafiscal { get; set; }
        public string Data { get; set; }
        public double Total { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int CPF { get; set; }
        public Caixa Caixa { get; set; }
        public int IdMovimento { get; set; }
    }
}