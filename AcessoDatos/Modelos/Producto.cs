using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
    public class Producto
    {
        public int ProductoId {get;set;}
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

        public string Nombre { get; set; }
         public  Imagen  Imagen { get; set; }

    }
}
