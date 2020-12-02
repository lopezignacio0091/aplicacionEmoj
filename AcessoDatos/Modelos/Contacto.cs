using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos.Modelos
{
    public class Contacto
    {
       public int ContactoId { get; set; }
       public string Nombre { get; set; }
        
       public string Email { get; set; }

       public string Mensaje { get; set; }

    }
}
