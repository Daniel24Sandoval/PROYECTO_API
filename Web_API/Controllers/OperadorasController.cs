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
    public class OperadorasController : ControllerBase
    {
        private readonly Soa24Context _context;

        public OperadorasController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Operadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operadora>>> GetOperadoras()
        {
            return await _context.Operadoras.ToListAsync();
        }

        // GET: api/Operadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operadora>> GetOperadora(int id)
        {
            var operadora = await _context.Operadoras.FindAsync(id);

            if (operadora == null)
            {
                return NotFound();
            }

            return operadora;
        }

        // PUT: api/Operadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperadora(int id, Operadora operadora)
        {
            if (id != operadora.IdOperadora)
            {
                return BadRequest();
            }

            _context.Entry(operadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperadoraExists(id))
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

        // POST: api/Operadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operadora>> PostOperadora(Operadora operadora)
        {
            _context.Operadoras.Add(operadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperadora", new { id = operadora.IdOperadora }, operadora);
        }

        // DELETE: api/Operadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperadora(int id)
        {
            var operadora = await _context.Operadoras.FindAsync(id);
            if (operadora == null)
            {
                return NotFound();
            }

            _context.Operadoras.Remove(operadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperadoraExists(int id)
        {
            return _context.Operadoras.Any(e => e.IdOperadora == id);
        }
    }
}
