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
    public class CurtidumsController : ControllerBase
    {
        private readonly RedeSocialContext _context;

        public CurtidumsController(RedeSocialContext context)
        {
            _context = context;
        }

        // GET: api/Curtidums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curtidum>>> GetCurtida()
        {
            return await _context.Curtida.ToListAsync();
        }

        // GET: api/Curtidums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curtidum>> GetCurtidum(Guid id)
        {
            var curtidum = await _context.Curtida.FindAsync(id);

            if (curtidum == null)
            {
                return NotFound();
            }

            return curtidum;
        }

        // PUT: api/Curtidums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurtidum(Guid id, Curtidum curtidum)
        {
            if (id != curtidum.Id)
            {
                return BadRequest();
            }

            _context.Entry(curtidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurtidumExists(id))
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

        // POST: api/Curtidums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curtidum>> PostCurtidum(Curtidum curtidum)
        {
            _context.Curtida.Add(curtidum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurtidum", new { id = curtidum.Id }, curtidum);
        }

        // DELETE: api/Curtidums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurtidum(Guid id)
        {
            var curtidum = await _context.Curtida.FindAsync(id);
            if (curtidum == null)
            {
                return NotFound();
            }

            _context.Curtida.Remove(curtidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurtidumExists(Guid id)
        {
            return _context.Curtida.Any(e => e.Id == id);
        }
    }
}
