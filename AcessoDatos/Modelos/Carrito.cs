using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
   public class Carrito
    {
        public int CarritoId { get; set; }
        public List<CarritoProducto> ListaCarritoProductos { get; set; }
        public int  UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set;}
        public String Estado { get; set;}
    }
}
