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
    public class PagoServiciosController : ControllerBase
    {
        private readonly Soa24Context _context;

        public PagoServiciosController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/PagoServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoServicio>>> GetPagoServicios()
        {
            return await _context.PagoServicios.ToListAsync();
        }

        // GET: api/PagoServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagoServicio>> GetPagoServicio(int id)
        {
            var pagoServicio = await _context.PagoServicios.FindAsync(id);

            if (pagoServicio == null)
            {
                return NotFound();
            }

            return pagoServicio;
        }
        
        // PUT: api/PagoServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagoServicio(int id, PagoServicio pagoServicio)
        {
            if (id != pagoServicio.IdPagoServicio)
            {
                return BadRequest();
            }

            _context.Entry(pagoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoServicioExists(id))
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

        // POST: api/PagoServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PagoServicio>> PostPagoServicio(int idFacturaPago, int idUsuario, decimal montoPagado)
        {
            // Encuentra la cuenta asociada con el IdUsuario
            var cuentaUsuario = await _context.Cuenta.FirstOrDefaultAsync(c => c.IdUsuario == idUsuario);

            // Verifica que la cuenta exista
            if (cuentaUsuario == null)
            {
                return NotFound("Cuenta no encontrada.");
            }

            // Verifica que haya saldo suficiente en la cuenta para realizar el pago
            if (cuentaUsuario.Saldo == null || cuentaUsuario.Saldo < montoPagado)
            {
                return BadRequest("Saldo insuficiente para realizar el pago.");
            }

            // Si hay saldo suficiente, crea el objeto PagoServicio con los parámetros proporcionados y la fecha actual
            PagoServicio pagoServicio = new PagoServicio
            {
                IdFacturaPago = idFacturaPago,
                IdUsuario = idUsuario,
                MontoPagado = montoPagado,
                FechaPago = DateTime.Now // Asigna la fecha y hora actual
            };



            // Guarda el PagoServicio en la base de datos
            _context.PagoServicios.Add(pagoServicio);
            await _context.SaveChangesAsync();

            // Retorna el registro de PagoServicio creado
            return CreatedAtAction("GetPagoServicio", new { id = pagoServicio.IdPagoServicio }, pagoServicio);
        }


        // DELETE: api/PagoServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagoServicio(int id)
        {
            var pagoServicio = await _context.PagoServicios.FindAsync(id);
            if (pagoServicio == null)
            {
                return NotFound();
            }

            _context.PagoServicios.Remove(pagoServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoServicioExists(int id)
        {
            return _context.PagoServicios.Any(e => e.IdPagoServicio == id);
        }
    }
}
