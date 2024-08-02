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
    public class DireccionEntregasController : ControllerBase
    {
        private readonly Soa24Context _context;

        public DireccionEntregasController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/DireccionEntregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DireccionEntrega>>> GetDireccionEntregas()
        {
            return await _context.DireccionEntregas.ToListAsync();
        }

        // GET: api/DireccionEntregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DireccionEntrega>> GetDireccionEntrega(int id)
        {
            var direccionEntrega = await _context.DireccionEntregas.FindAsync(id);

            if (direccionEntrega == null)
            {
                return NotFound();
            }

            return direccionEntrega;
        }

        // PUT: api/DireccionEntregas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccionEntrega(int id, DireccionEntrega direccionEntrega)
        {
            if (id != direccionEntrega.IdDireccion)
            {
                return BadRequest();
            }

            _context.Entry(direccionEntrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionEntregaExists(id))
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

        // POST: api/DireccionEntregas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DireccionEntrega>> PostDireccionEntrega(DireccionEntrega direccionEntrega)
        {
            _context.DireccionEntregas.Add(direccionEntrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDireccionEntrega", new { id = direccionEntrega.IdDireccion }, direccionEntrega);
        }

        // DELETE: api/DireccionEntregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccionEntrega(int id)
        {
            var direccionEntrega = await _context.DireccionEntregas.FindAsync(id);
            if (direccionEntrega == null)
            {
                return NotFound();
            }

            _context.DireccionEntregas.Remove(direccionEntrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DireccionEntregaExists(int id)
        {
            return _context.DireccionEntregas.Any(e => e.IdDireccion == id);
        }
    }
}
