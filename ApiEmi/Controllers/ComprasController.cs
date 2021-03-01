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
    public class ComprasController : ControllerBase
    {
        public ComprasController(BdEmiContext context)
        {
            this._context = context;
        }
        private readonly BdEmiContext _context;


        [HttpPost]
        public async Task<ActionResult> postCarrito(Carrito carrito)
        {

            Compra compra = new Compra();
            DateTime Hoy = DateTime.Today;
            Usuario usuario = await _context.Usuarios.Include(x => x.Carrito).ThenInclude(x => x.ListaCarritoProductos ).ThenInclude(x => x.Producto).FirstOrDefaultAsync(x => x.Id == carrito.UsuarioId);


            usuario.Carrito.ListaCarritoProductos.Where(x => x.Deleted == false);
            compra.Fecha = Hoy;
            compra.listaCarritoProductos = usuario.Carrito.ListaCarritoProductos;
            compra.Total = usuario.Carrito.Total;
            compra.usuario = usuario;

            descontarProducto(compra.listaCarritoProductos);
            await _context.Compras.AddAsync(compra);
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            inicilizandoCarrito(usuario.Carrito);
            return Created(" Se Realizo la compra con exito ", carrito);
        }

        public async void inicilizandoCarrito(Carrito carrito)
        {

            carrito.ListaCarritoProductos.Clear();
            carrito.Total = 0;

            _context.Entry(carrito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async void descontarProducto(List<CarritoProducto> listaCarritoProducto) {
             
            try
                {  
               var listaProductos = await _context.Productos.ToListAsync();
                    foreach(CarritoProducto c in listaCarritoProducto) {
                    Producto producto = listaProductos.FirstOrDefault(x => x.ProductoId == c.Producto.ProductoId);
                    if (producto.Stock != 0)
                    {
                        producto.Stock = producto.Stock - c.Cantidad;
                        _context.Entry(producto).State = EntityState.Modified;
                    }
                }

                
                   
            }
            catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            var listaCompras = await _context.Compras.Include(x=>x.listaCarritoProductos).ThenInclude(x => x.Producto).Include(x=>x.usuario).ToListAsync();
            return Ok(listaCompras);
        }
    }
}