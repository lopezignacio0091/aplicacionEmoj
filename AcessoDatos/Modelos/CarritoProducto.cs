using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
    public class CarritoProducto
    {
        public int id { get; set; }
        public int Cantidad { get; set; }
        public virtual Producto Producto { get; set; }
        public decimal Precio { get; set; }
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Deleted {get;set;}

    }
}
