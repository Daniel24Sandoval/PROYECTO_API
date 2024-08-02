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
    public class TipoEntradumsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public TipoEntradumsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/TipoEntradums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEntradum>>> GetTipoEntrada()
        {
            return await _context.TipoEntrada.ToListAsync();
        }

        // GET: api/TipoEntradums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEntradum>> GetTipoEntradum(int id)
        {
            var tipoEntradum = await _context.TipoEntrada.FindAsync(id);

            if (tipoEntradum == null)
            {
                return NotFound();
            }

            return tipoEntradum;
        }

        // PUT: api/TipoEntradums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEntradum(int id, TipoEntradum tipoEntradum)
        {
            if (id != tipoEntradum.IdTipoEntrada)
            {
                return BadRequest();
            }

            _context.Entry(tipoEntradum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEntradumExists(id))
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

        // POST: api/TipoEntradums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEntradum>> PostTipoEntradum(TipoEntradum tipoEntradum)
        {
            _context.TipoEntrada.Add(tipoEntradum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEntradum", new { id = tipoEntradum.IdTipoEntrada }, tipoEntradum);
        }

        // DELETE: api/TipoEntradums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEntradum(int id)
        {
            var tipoEntradum = await _context.TipoEntrada.FindAsync(id);
            if (tipoEntradum == null)
            {
                return NotFound();
            }

            _context.TipoEntrada.Remove(tipoEntradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEntradumExists(int id)
        {
            return _context.TipoEntrada.Any(e => e.IdTipoEntrada == id);
        }
    }
}
