using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFerias.Models
{
    public class Cliente
    {
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string RG { get; set; }
        public int Celular { get; set; }
        public int NumEnd { get; set; }
        public string CompEnd { get; set; }
        public Endereco Endereco { get; set; }
    }
}