using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
   public class Carrito
    {
        public int CarritoId { get; set; }
        public virtual List<CarritoProducto> ListaCarritoProductos { get; set; }
        public int  UsuarioId { get; set; }
        public decimal Total { get; set;}
        public String Estado { get; set;}
      
    }
}
