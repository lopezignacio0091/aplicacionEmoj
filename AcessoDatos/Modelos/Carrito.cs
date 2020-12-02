using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
   public class Carrito
    {
        public int CarritoId { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public int  UsuarioId { get; set; }
        public DateTime fecha { get; set; }
       
    }
}
