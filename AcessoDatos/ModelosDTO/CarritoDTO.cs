using AcessoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.ModelosDTO
{
   public class CarritoDTO
    {
        public int CarritoId { get; set; }
        public virtual List<CarritoProducto> ListaCarritoProductos { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public String Estado { get; set; }
        public List<Producto> listaProducto { get; set; } = new List<Producto>();
    }
}
