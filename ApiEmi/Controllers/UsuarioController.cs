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
    public class UsuarioController : ControllerBase
    {
        private readonly BdEmiContext _context;

        public UsuarioController(BdEmiContext context)
        {
            this._context = context;
        }


        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            var listaUsuario = await _context.Usuarios.ToListAsync();
            if (listaUsuario.Count == 0)
            {
                return NoContent();
            }
            return Ok(listaUsuario);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioId(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            //Producto producto = await _context.Productos.FirstOrDefaultAsync(x=>x.ProductoId == id);
            if (usuario == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(usuario);
        }
        [HttpGet("{email},{password}")]
        public async Task<ActionResult<Usuario>> GetUsuarioEmail(String email , String password)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Password==password);
            //Producto producto = await _context.Productos.FirstOrDefaultAsync(x=>x.ProductoId == id);
            if (usuario == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> postUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Created("Se dio de alta un Usuario", usuario);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Usuario>> GetUsuarioCheckEmail(String email, String password)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
     
            if (usuario == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(usuario);
        }
    }
}
