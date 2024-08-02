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
    public class TarjetumsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public TarjetumsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Tarjetums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarjetum>>> GetTarjeta()
        {
            return await _context.Tarjeta.ToListAsync();
        }

        // GET: api/Tarjetums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarjetum>> GetTarjetum(int id)
        {
            var tarjetum = await _context.Tarjeta.FindAsync(id);

            if (tarjetum == null)
            {
                return NotFound();
            }

            return tarjetum;
        }

        // PUT: api/Tarjetums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetum(int id, Tarjetum tarjetum)
        {
            if (id != tarjetum.IdTarjeta)
            {
                return BadRequest();
            }

            _context.Entry(tarjetum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetumExists(id))
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

        // POST: api/Tarjetums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarjetum>> PostTarjetum(Tarjetum tarjetum)
        {
            _context.Tarjeta.Add(tarjetum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetum", new { id = tarjetum.IdTarjeta }, tarjetum);
        }

        // DELETE: api/Tarjetums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarjetum(int id)
        {
            var tarjetum = await _context.Tarjeta.FindAsync(id);
            if (tarjetum == null)
            {
                return NotFound();
            }

            _context.Tarjeta.Remove(tarjetum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarjetumExists(int id)
        {
            return _context.Tarjeta.Any(e => e.IdTarjeta == id);
        }
    }
}
