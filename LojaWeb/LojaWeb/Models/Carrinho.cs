using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public double PrecoFinal { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public IList<ItemCarrinho> itemCarrinhos { get; set; }
        public bool Estado { get; set; }
    }
}