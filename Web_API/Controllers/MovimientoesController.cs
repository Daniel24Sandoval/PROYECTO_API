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
    public class MovimientoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public MovimientoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Movimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
        {
            return await _context.Movimientos.ToListAsync();
        }

        // GET: api/Movimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return movimiento;
        }

        // PUT: api/Movimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimiento(int id, Movimiento movimiento)
        {
            if (id != movimiento.IdMovimiento)
            {
                return BadRequest();
            }

            _context.Entry(movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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

        // POST: api/Movimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {
            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimiento", new { id = movimiento.IdMovimiento }, movimiento);
        }

        // DELETE: api/Movimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientoExists(int id)
        {
            return _context.Movimientos.Any(e => e.IdMovimiento == id);
        }

        // GET: api/Movimientoes/{idCuenta}/{idUsuario}
        [HttpGet("{idCuenta}/{idUsuario}")]
        public async Task<ActionResult> GetMovimientos(int idCuenta, int idUsuario)
        {
            var movimientos = await _context.Movimientos
                .Include(m => m.IdCuentaDestinoNavigation)
                .ThenInclude(c => c.IdUsuarioNavigation)
                .Include(m => m.IdCuentaDestinoNavigation)
                .ThenInclude(c => c.IdEmpresaNavigation)
                .Where(m => m.IdCuentaOrigen == idCuenta || m.IdCuentaDestino == idCuenta)
                .Select(m => new
                {
                    NombreDestino = m.IdCuentaDestinoNavigation.IdUsuarioNavigation != null ? m.IdCuentaDestinoNavigation.IdUsuarioNavigation.Nombre :
                                    m.IdCuentaDestinoNavigation.IdEmpresaNavigation != null ? m.IdCuentaDestinoNavigation.IdEmpresaNavigation.Nombre : null,
                    Fecha = m.Fecha,
                    Monto = m.IdCuentaOrigen == idCuenta ? -m.Monto : m.Monto,
                    NombreServicio = m.NombreServicio
                })
                .ToListAsync();

            if (movimientos == null || movimientos.Count == 0)
            {
                return NotFound();
            }

            return Ok(movimientos);
        }
    }
}
