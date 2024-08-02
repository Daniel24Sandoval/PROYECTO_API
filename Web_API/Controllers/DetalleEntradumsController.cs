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
    public class DetalleEntradumsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public DetalleEntradumsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/DetalleEntradums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleEntradum>>> GetDetalleEntrada()
        {
            return await _context.DetalleEntrada.ToListAsync();
        }

        // GET: api/DetalleEntradums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleEntradum>> GetDetalleEntradum(int id)
        {
            var detalleEntradum = await _context.DetalleEntrada.FindAsync(id);

            if (detalleEntradum == null)
            {
                return NotFound();
            }

            return detalleEntradum;
        }

        // PUT: api/DetalleEntradums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleEntradum(int id, DetalleEntradum detalleEntradum)
        {
            if (id != detalleEntradum.IdDetalleEntrada)
            {
                return BadRequest();
            }

            _context.Entry(detalleEntradum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleEntradumExists(id))
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

        // POST: api/DetalleEntradums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleEntradum>> PostDetalleEntradum(DetalleEntradum detalleEntradum)
        {
            _context.DetalleEntrada.Add(detalleEntradum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleEntradum", new { id = detalleEntradum.IdDetalleEntrada }, detalleEntradum);
        }

        // DELETE: api/DetalleEntradums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleEntradum(int id)
        {
            var detalleEntradum = await _context.DetalleEntrada.FindAsync(id);
            if (detalleEntradum == null)
            {
                return NotFound();
            }

            _context.DetalleEntrada.Remove(detalleEntradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleEntradumExists(int id)
        {
            return _context.DetalleEntrada.Any(e => e.IdDetalleEntrada == id);
        }
    }
}
