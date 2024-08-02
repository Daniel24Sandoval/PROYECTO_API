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
    public class FacturaPagoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public FacturaPagoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/FacturaPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaPago>>> GetFacturaPagos()
        {
            return await _context.FacturaPagos.ToListAsync();
        }

        // GET: api/FacturaPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaPago>> GetFacturaPago(int id)
        {
            var facturaPago = await _context.FacturaPagos.FindAsync(id);

            if (facturaPago == null)
            {
                return NotFound();
            }

            return facturaPago;
        }


        [HttpGet("DeudaPorDniYEmpresa")]
        public async Task<ActionResult<IEnumerable<object>>> GetDeudaPorDniYEmpresa(int dni, int idEmpresa)
        {
            // Primero, encuentra el usuario basado en el DNI proporcionado
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Dniuser == dni);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Luego, busca las facturas de pago que coincidan con el IdUsuario e IdEmpresa
            var deudas = await _context.FacturaPagos
                .Where(fp => fp.IdUsuario == usuario.IdUsuario && fp.IdEmpresa == idEmpresa)
                .Select(fp => new
                {
                    fp.IdFacturaPago, fp.IdUsuario,fp.CodigoCliente,
                    MontoAPagar = fp.MontoAPagar ?? 0,  
                    FechaPago = fp.FechaPago.HasValue ? fp.FechaPago.Value.ToString("yyyy-MM-dd") : null, // Formatea la fecha
                    fp.Estado
                })
                .ToListAsync();

            if (!deudas.Any())
            {
                return NotFound("No se encontraron deudas para el usuario con la empresa especificada.");
            }

            return deudas;
        }




        // PUT: api/FacturaPagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaPago(int id, FacturaPago facturaPago)
        {
            if (id != facturaPago.IdFacturaPago)
            {
                return BadRequest();
            }

            _context.Entry(facturaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaPagoExists(id))
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

        // POST: api/FacturaPagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaPago>> PostFacturaPago(FacturaPago facturaPago)
        {
            _context.FacturaPagos.Add(facturaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaPago", new { id = facturaPago.IdFacturaPago }, facturaPago);
        }

        // DELETE: api/FacturaPagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaPago(int id)
        {
            var facturaPago = await _context.FacturaPagos.FindAsync(id);
            if (facturaPago == null)
            {
                return NotFound();
            }

            _context.FacturaPagos.Remove(facturaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaPagoExists(int id)
        {
            return _context.FacturaPagos.Any(e => e.IdFacturaPago == id);
        }
    }
}
