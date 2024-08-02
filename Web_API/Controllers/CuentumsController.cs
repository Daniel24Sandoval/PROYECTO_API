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
    public class CuentumsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CuentumsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Cuentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentum>>> GetCuenta()
        {
            return await _context.Cuenta.ToListAsync();
        }

        // GET: api/Cuentums/usuario/5
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult> GetCuentumByUsuario(int idUsuario)
        {
            var cuentum = await _context.Cuenta
                .Where(c => c.IdUsuario == idUsuario)
                .Select(c => new { c.IdCuenta, c.Saldo })
                .FirstOrDefaultAsync();

            if (cuentum == null)
            {
                return NotFound();
            }

            return Ok(cuentum);
        }
        // PUT: api/Cuentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentum(int id, Cuentum cuentum)
        {
            if (id != cuentum.IdCuenta)
            {
                return BadRequest();
            }

            _context.Entry(cuentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentumExists(id))
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

        // POST: api/Cuentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuentum>> PostCuentum(Cuentum cuentum)
        {
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentum", new { id = cuentum.IdCuenta }, cuentum);
        }

        // DELETE: api/Cuentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentum(int id)
        {
            var cuentum = await _context.Cuenta.FindAsync(id);
            if (cuentum == null)
            {
                return NotFound();
            }

            _context.Cuenta.Remove(cuentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentumExists(int id)
        {
            return _context.Cuenta.Any(e => e.IdCuenta == id);
        }
    }
}
