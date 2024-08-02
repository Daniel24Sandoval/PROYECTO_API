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
    public class CompraEsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CompraEsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/CompraEs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraE>>> GetCompraEs()
        {
            return await _context.CompraEs.ToListAsync();
        }

        // GET: api/CompraEs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraE>> GetCompraE(int id)
        {
            var compraE = await _context.CompraEs.FindAsync(id);

            if (compraE == null)
            {
                return NotFound();
            }

            return compraE;
        }

        // PUT: api/CompraEs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraE(int id, CompraE compraE)
        {
            if (id != compraE.IdCompraEntrada)
            {
                return BadRequest();
            }

            _context.Entry(compraE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraEExists(id))
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

        // POST: api/CompraEs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraE>> PostCompraE(CompraE compraE)
        {
            _context.CompraEs.Add(compraE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompraE", new { id = compraE.IdCompraEntrada }, compraE);
        }

        // DELETE: api/CompraEs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraE(int id)
        {
            var compraE = await _context.CompraEs.FindAsync(id);
            if (compraE == null)
            {
                return NotFound();
            }

            _context.CompraEs.Remove(compraE);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraEExists(int id)
        {
            return _context.CompraEs.Any(e => e.IdCompraEntrada == id);
        }
    }
}
