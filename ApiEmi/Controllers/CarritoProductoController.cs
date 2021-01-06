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
    public class CarritoProductoController : ControllerBase
    {
        public CarritoProductoController(BdEmiContext context)
        {
            this._context = context;
        }
        private readonly BdEmiContext _context;


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