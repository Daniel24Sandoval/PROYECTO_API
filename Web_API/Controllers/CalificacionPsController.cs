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
    public class CalificacionPsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CalificacionPsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/CalificacionPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificacionP>>> GetCalificacionPs()
        {
            return await _context.CalificacionPs.ToListAsync();
        }

        // GET: api/CalificacionPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalificacionP>> GetCalificacionP(int id)
        {
            var calificacionP = await _context.CalificacionPs.FindAsync(id);

            if (calificacionP == null)
            {
                return NotFound();
            }

            return calificacionP;
        }

        // PUT: api/CalificacionPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacionP(int id, CalificacionP calificacionP)
        {
            if (id != calificacionP.IdCalificacion)
            {
                return BadRequest();
            }

            _context.Entry(calificacionP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionPExists(id))
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

        // POST: api/CalificacionPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalificacionP>> PostCalificacionP(CalificacionP calificacionP)
        {
            _context.CalificacionPs.Add(calificacionP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificacionP", new { id = calificacionP.IdCalificacion }, calificacionP);
        }

        // DELETE: api/CalificacionPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacionP(int id)
        {
            var calificacionP = await _context.CalificacionPs.FindAsync(id);
            if (calificacionP == null)
            {
                return NotFound();
            }

            _context.CalificacionPs.Remove(calificacionP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionPExists(int id)
        {
            return _context.CalificacionPs.Any(e => e.IdCalificacion == id);
        }
    }
}
