using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionEventoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public UbicacionEventoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/UbicacionEventoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionEvento>>> GetUbicacionEventos()
        {
            return await _context.UbicacionEventos.ToListAsync();
        }

        // GET: api/UbicacionEventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionEvento>> GetUbicacionEvento(int id)
        {
            var ubicacionEvento = await _context.UbicacionEventos.FindAsync(id);

            if (ubicacionEvento == null)
            {
                return NotFound();
            }

            return ubicacionEvento;
        }

        // PUT: api/UbicacionEventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacionEvento(int id, UbicacionEvento ubicacionEvento)
        {
            if (id != ubicacionEvento.IdUbicacionEvento)
            {
                return BadRequest();
            }

            _context.Entry(ubicacionEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionEventoExists(id))
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

        // POST: api/UbicacionEventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UbicacionEvento>> PostUbicacionEvento(UbicacionEvento ubicacionEvento)
        {
            _context.UbicacionEventos.Add(ubicacionEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacionEvento", new { id = ubicacionEvento.IdUbicacionEvento }, ubicacionEvento);
        }

        // DELETE: api/UbicacionEventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacionEvento(int id)
        {
            var ubicacionEvento = await _context.UbicacionEventos.FindAsync(id);
            if (ubicacionEvento == null)
            {
                return NotFound();
            }

            _context.UbicacionEventos.Remove(ubicacionEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacionEventoExists(int id)
        {
            return _context.UbicacionEventos.Any(e => e.IdUbicacionEvento == id);
        }
    }
}
