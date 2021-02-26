using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
    public class Compra
    {
        public int Id { get; set;}
        public decimal Total { get; set;}
        public DateTime Fecha { get; set; }
        public virtual List<CarritoProducto> listaCarritoProductos { get; set;}
    }
}
