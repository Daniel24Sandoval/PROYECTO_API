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
    public class CompraTsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CompraTsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/CompraTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraT>>> GetCompraTs()
        {
            return await _context.CompraTs.ToListAsync();
        }

        // GET: api/CompraTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraT>> GetCompraT(int id)
        {
            var compraT = await _context.CompraTs.FindAsync(id);

            if (compraT == null)
            {
                return NotFound();
            }

            return compraT;
        }

        // PUT: api/CompraTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraT(int id, CompraT compraT)
        {
            if (id != compraT.IdCompraTienda)
            {
                return BadRequest();
            }

            _context.Entry(compraT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraTExists(id))
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

        // POST: api/CompraTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraT>> PostCompraT(CompraT compraT)
        {
            _context.CompraTs.Add(compraT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompraT", new { id = compraT.IdCompraTienda }, compraT);
        }

        // DELETE: api/CompraTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraT(int id)
        {
            var compraT = await _context.CompraTs.FindAsync(id);
            if (compraT == null)
            {
                return NotFound();
            }

            _context.CompraTs.Remove(compraT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraTExists(int id)
        {
            return _context.CompraTs.Any(e => e.IdCompraTienda == id);
        }
    }
}
