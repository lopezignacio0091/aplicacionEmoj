using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessoDatos;
using AcessoDatos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEmi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BdEmiContext _context;

        public ProductoController(BdEmiContext context)
        {
            this._context = context;
        }


        public async Task<ActionResult <IEnumerable<Producto>>> GetProductos()
        {

            
            var listaProductos = await _context.Productos.Include(x=>x.Imagen).Where(x=>x.ProductoId == x.Imagen.ProductoId).ToListAsync();
            if (listaProductos.Count == 0) {
                return NoContent();
            }
            return Ok(listaProductos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult <Producto>> GetProductos2(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            //Producto producto = await _context.Productos.FirstOrDefaultAsync(x=>x.ProductoId == id);
            if(producto == null)
            {

                return NotFound("El producto no existe");
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> postCarritoProducto(CarritoProducto carritoProducto)
        {
            carritoProducto.Precio = carritoProducto.Cantidad * carritoProducto.Producto.Precio;
            await _context.CarritoProductos.AddAsync(carritoProducto);
            await _context.SaveChangesAsync();

            return Created(" Se creo un carrito ", carritoProducto);
        }
    }
}