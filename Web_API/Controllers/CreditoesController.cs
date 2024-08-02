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
    public class CreditoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CreditoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Creditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credito>>> GetCreditos()
        {
            return await _context.Creditos.ToListAsync();
        }

        // GET: api/Creditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credito>> GetCredito(int id)
        {
            var credito = await _context.Creditos.FindAsync(id);

            if (credito == null)
            {
                return NotFound();
            }

            return credito;
        }

        // PUT: api/Creditoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredito(int id, Credito credito)
        {
            if (id != credito.IdCredito)
            {
                return BadRequest();
            }

            _context.Entry(credito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditoExists(id))
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

        // POST: api/Creditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Credito>> PostCredito(Credito credito)
        {
            _context.Creditos.Add(credito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { id = credito.IdCredito }, credito);
        }

        // DELETE: api/Creditoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredito(int id)
        {
            var credito = await _context.Creditos.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }

            _context.Creditos.Remove(credito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditoExists(int id)
        {
            return _context.Creditos.Any(e => e.IdCredito == id);
        }
    }
}
