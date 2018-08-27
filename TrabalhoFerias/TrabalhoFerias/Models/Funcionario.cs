using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobre { get; set; }
        public int Telefone { get; set; }
        public Endereco Endereco{ get; set; }
        public int NumEnd { get; set; }
        public int CompEnd { get; set; }
    }
}