using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Data;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private readonly RedeSocialContext _context;

        public TipoUsuariosController(RedeSocialContext context)
        {
            _context = context;
        }

        // GET: api/TipoUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> GetTipoUsuarios()
        {
            return await _context.TipoUsuarios.ToListAsync();
        }

        // GET: api/TipoUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetTipoUsuario(Guid id)
        {
            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return tipoUsuario;
        }

        // PUT: api/TipoUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuario(Guid id, TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> PostTipoUsuario(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuarios.Add(tipoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUsuario", new { id = tipoUsuario.Id }, tipoUsuario);
        }

        // DELETE: api/TipoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUsuario(Guid id)
        {
            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            _context.TipoUsuarios.Remove(tipoUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoUsuarioExists(Guid id)
        {
            return _context.TipoUsuarios.Any(e => e.Id == id);
        }
    }
}
