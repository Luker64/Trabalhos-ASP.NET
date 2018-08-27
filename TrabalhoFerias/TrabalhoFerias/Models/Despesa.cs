using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Codigo { get; set; }
        public Caixa Caixa { get; set; }
        public int IdMovimento { get; set; }
    }
}