using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
    public class Imagen
    {
        public int ProductoId { get; set; }
        public int ImagenId { get; set; }
        public Producto Producto { get; set; }
        public string ImagenUrl { get; set; }


    }
}
