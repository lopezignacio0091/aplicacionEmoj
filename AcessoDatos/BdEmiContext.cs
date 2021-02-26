using AcessoDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDatos
{
    public class BdEmiContext: DbContext
    {
        public BdEmiContext(DbContextOptions<BdEmiContext> options):base(options)
        {   
                
        }


        public DbSet<Producto> Productos { get; set; }

        public DbSet<Imagen> Imagenes { get; set; }

        public DbSet<Contacto> Contacto { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Carrito> Carrito { get; set; }

        public DbSet<CarritoProducto> CarritoProductos { get; set;}

        public DbSet<Compra> Compras { get; set;}
    }
}
