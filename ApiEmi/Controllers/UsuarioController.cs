using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessoDatos;
using AcessoDatos.Modelos;
using AcessoDatos.ModelosDTO;
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
        public UsuarioDTO UsuarioDTO { get; set; }
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
            try
            { 
               
                 Usuario usuario = await _context.Usuarios.Include(x =>x.Carrito).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                if (usuario.EsAdmin != true) {
                    await _context.CarritoProductos.Include(x => x.Producto).Where(x => x.CarritoId == usuario.Carrito.CarritoId && x.Deleted == false).ToListAsync();
                }
              
                
                if (usuario == null)
                            {
                                return NotFound("El usuario no existe");
                            }
                   return Ok(usuario);
            }
            catch (Exception e) {
                throw e;
            }
            
           
        }

        [HttpPost]
        public async Task<ActionResult> postUsuario(Usuario usuario)
        {
            Usuario usuarioBd = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (usuarioBd == null) {
             await _context.Usuarios.AddAsync(usuario);
             await _context.SaveChangesAsync();
            }

         
            return Created("Se dio de alta un Usuario", usuario);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Usuario>> GetUsuarioCheckEmail(String email, String password)
        {
            Usuario usuario = await _context.Usuarios.Include(x => x.Carrito).ThenInclude(x => x.ListaCarritoProductos).ThenInclude(x => x.Producto).FirstOrDefaultAsync(x => x.Email == email);
            usuario.Carrito.ListaCarritoProductos = usuario.Carrito.ListaCarritoProductos.Where(x => x.Deleted == false).ToList();


            if (usuario == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(usuario);
        }


        [HttpPut]
        public async Task<ActionResult<Usuario>> updateUsuario(Usuario usuario)
        {
            Usuario usuarioDTO = await _context.Usuarios.Include(x => x.Carrito).ThenInclude(x => x.ListaCarritoProductos).ThenInclude(x => x.Producto).FirstOrDefaultAsync(x => x.Email == usuario.Email);
            usuarioDTO.Carrito.ListaCarritoProductos = usuarioDTO.Carrito.ListaCarritoProductos.Where(x => x.Deleted == false).ToList();

            usuarioDTO.Password = usuario.Password;

            _context.Entry(usuarioDTO).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            if (usuarioDTO == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(usuarioDTO);
        }
    }

  
}
