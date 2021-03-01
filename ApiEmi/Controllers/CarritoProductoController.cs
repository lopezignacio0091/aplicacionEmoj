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

        public async Task<ActionResult<IEnumerable<Carrito>>> GetCarrito()
        {
            var carrito = await _context.Carrito.ToListAsync();
            if (carrito.Count == 0)
            {
                return NoContent();
            }
            return Ok(carrito);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Carrito>> GetCarritoUser(int idUser)
        {
            //Producto producto = await _context.Productos.FindAsync(id);
            Carrito carrito = await _context.Carrito.FirstOrDefaultAsync(x=>x.UsuarioId == idUser);
            if (carrito == null)
            {

                return NotFound("Usted no posee carrito");
            }

            return Ok(carrito);
        }


        [HttpPut]
        public async Task<ActionResult<Carrito>> DeleteCarritoProducto(CarritoProducto carritoProducto)
        {
            
                CarritoProducto carritoProductoDto = await _context.CarritoProductos.FirstOrDefaultAsync(x => x.id == carritoProducto.id);
                Carrito carrito = await _context.Carrito.FirstOrDefaultAsync(x => x.CarritoId == carritoProductoDto.CarritoId);

                carrito.Total = carrito.Total - (carritoProductoDto.Precio * carritoProducto.Cantidad);

                carritoProductoDto.Deleted = true;

                _context.Entry(carritoProductoDto).State = EntityState.Modified;
                _context.Entry(carrito).State = EntityState.Modified;

                if (carritoProducto == null)
                {

                    return NotFound("Usted no posee carrito");
                }

                await _context.SaveChangesAsync();
                return Ok(carritoProductoDto);
                     
        }



        [HttpPost]
        public async Task<ActionResult> postCarrito(CarritoProducto carritoProducto)
        {
            DateTime hoy = DateTime.Today;
            Carrito carrito = await _context.Carrito.FirstOrDefaultAsync(x => x.CarritoId == carritoProducto.CarritoId);
            Producto producto = await _context.Productos.FirstOrDefaultAsync(x => x.ProductoId == carritoProducto.ProductoId);
            CarritoProducto carritoProductoDto = await _context.CarritoProductos.FirstOrDefaultAsync(x => x.CarritoId == carritoProducto.CarritoId && x.ProductoId == carritoProducto.ProductoId && x.Deleted== false);

            if (carritoProductoDto == null)
            {
                carritoProducto.Producto = producto;
                carritoProducto.Precio = carritoProducto.Cantidad * producto.Precio;
                carritoProducto.Fecha = hoy;
                carritoProducto.Deleted = false;
                await _context.CarritoProductos.AddAsync(carritoProducto);



                carrito.ListaCarritoProductos.Add(carritoProducto);
                carrito.Total = carrito.Total + carritoProducto.Precio;

                _context.Entry(carrito).State = EntityState.Modified;

            }
            else {
                carritoProductoDto.Cantidad = carritoProductoDto.Cantidad + carritoProducto.Cantidad;
                carritoProductoDto.Precio = carritoProductoDto.Precio + (carritoProducto.Cantidad * producto.Precio);
                carrito.Total = carrito.Total + producto.Precio;

            

                _context.Entry(carrito).State = EntityState.Modified;
                _context.Entry(carritoProductoDto).State = EntityState.Modified;
            }
          

            await _context.SaveChangesAsync();
            return Created(" Se creo un carrito ", carritoProducto);
        }

    }
}