using AcessoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.ModelosDTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Boolean EsAdmin { get; set; }

        public string Password { get; set; }

        public virtual Carrito Carrito { get; set; }

        public int CarritoId { get; set; }
    }
}
