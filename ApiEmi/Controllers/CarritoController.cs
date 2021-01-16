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
    public class CarritoController : ControllerBase
    {
        public CarritoController(BdEmiContext context)
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
            
            Carrito carrito = await _context.Carrito.FirstOrDefaultAsync(x=>x.UsuarioId == idUser);
            if (carrito == null)
            {

                return NotFound("Usted no posee carrito");
            }

            return Ok(carrito);
        }

        [HttpPost]
        public async Task<ActionResult> postCarrito(Carrito carrito)
        {

            carrito.Estado = "Nuevo";
            Usuario usuario =  await _context.Usuarios.FirstOrDefaultAsync(x=>x.Id == carrito.UsuarioId);

            carrito.UsuarioId = usuario.Id;
            await _context.Carrito.AddAsync(carrito);
          
            usuario.Carrito = carrito;
            _context.Entry(usuario).State=EntityState.Modified;
            

            await _context.SaveChangesAsync();
            return Created(" Se creo un carrito ",carrito);
        }
    }
}