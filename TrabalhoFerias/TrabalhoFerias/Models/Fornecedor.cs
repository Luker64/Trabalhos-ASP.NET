using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Fornecedor
    {
        public int Codigo { get; set; }
        public int CNPJ { get; set; }
        public int Telefone { get; set; }
        public string Contato { get; set; }
        public Endereco Endereco { get; set; }
        public int NumEnd { get; set; }
        public int CompEnd { get; set; }
    }
}