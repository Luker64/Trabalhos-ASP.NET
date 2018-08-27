using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Endereco
    {
        public int CEP { get; set; }
        public string End { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        //public IList<Fornecedor> Fornecedores { get; set; }
        //public IList<Funcionario> Funcionarios { get; set; }
        //public IList<Cliente> Clientes { get; set; }
    }
}