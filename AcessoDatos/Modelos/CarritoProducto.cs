using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
   public class CarritoProducto
    {
        public int id { get; set;}
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public Carrito Carrito { get; set;}
        public double Precio { get; set;}
    }
}
