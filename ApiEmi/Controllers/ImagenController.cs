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
    public class ImagenController : ControllerBase
    {
        private readonly BdEmiContext _context;
        public ImagenController(BdEmiContext context)
        {
            this._context = context;
        }
        public async Task<ActionResult<IEnumerable<Imagen>>> GetImagen()
        {
           
            var listaImagenes = await _context.Imagenes.Include(x => x.Producto).ToListAsync();
        
            if (listaImagenes.Count == 0)
            {
                return NoContent();
            }
            return Ok(listaImagenes);
        }


        [HttpPost]
        public async Task<ActionResult> postProducto(Imagen imagen)
        {
            await _context.Imagenes.AddAsync(imagen);
            await _context.SaveChangesAsync();

            return Created("postProducto creo una imagen", imagen);
        }

    }
}