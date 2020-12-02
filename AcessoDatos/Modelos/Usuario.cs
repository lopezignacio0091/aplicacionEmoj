using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
  public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Boolean EsAdmin { get; set;}

        public string Password { get; set; }
    }
}
