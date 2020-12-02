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
    public class ContactoController : ControllerBase
    {
        public ContactoController(BdEmiContext context)
        {
            this._context = context;
        }
        private readonly BdEmiContext _context;

        public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto()
        {
            var listaContactos = await _context.Contacto.ToListAsync();
            if (listaContactos.Count == 0)
            {
                return NoContent();
            }
            return Ok(listaContactos);
        }

        [HttpPost]
        public async Task<ActionResult> postContacto(Contacto contacto)
        {
            await _context.Contacto.AddAsync(contacto);
            await _context.SaveChangesAsync();

            return Created("postProducto creo una imagen", contacto);
        }
    }
}