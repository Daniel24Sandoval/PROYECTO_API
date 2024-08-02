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
    public class YapeosController : ControllerBase
    {
        private readonly Soa24Context _context;

        public YapeosController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Yapeos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yapeo>>> GetYapeos()
        {
            return await _context.Yapeos.ToListAsync();
        }

        // GET: api/Yapeos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Yapeo>> GetYapeo(int id)
        {
            var yapeo = await _context.Yapeos.FindAsync(id);

            if (yapeo == null)
            {
                return NotFound();
            }

            return yapeo;
        }

        // PUT: api/Yapeos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYapeo(int id, Yapeo yapeo)
        {
            if (id != yapeo.IdYape)
            {
                return BadRequest();
            }

            _context.Entry(yapeo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YapeoExists(id))
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

        // POST: api/Yapeos/Yapear
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Yapear")]
        public async Task<ActionResult<Yapeo>> PostYapeo(Yapeo yapeo)
        {
            // Encuentra la cuenta del emisor usando IdUsuario
            var cuentaEmisor = await _context.Cuenta.FindAsync(yapeo.IdUsuario);

            // Verifica que la cuenta exista
            if (cuentaEmisor == null)
            {
                return NotFound("Cuenta del emisor no encontrada.");
            }

            // Verifica que el monto a enviar no sea mayor a 500 soles
            if (yapeo.Monto > 500)
            {
                return BadRequest("El monto no puede ser mayor a 500 soles.");
            }

            // Verifica que el saldo disponible en la cuenta del emisor sea suficiente
            if (cuentaEmisor.Saldo == null || cuentaEmisor.Saldo < yapeo.Monto)
            {
                return BadRequest("Saldo insuficiente para realizar el Yapeo.");
            }

            // Asigna la fecha y hora actual
            yapeo.FechaHora = DateTime.Now;

            // Si pasa todas las validaciones, procede a insertar el registro de Yapeo
            _context.Yapeos.Add(yapeo);
            await _context.SaveChangesAsync();

            // Retorna el registro de Yapeo creado
            return CreatedAtAction("GetYapeo", new { id = yapeo.IdYape }, yapeo);
        }


        // DELETE: api/Yapeos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYapeo(int id)
        {
            var yapeo = await _context.Yapeos.FindAsync(id);
            if (yapeo == null)
            {
                return NotFound();
            }

            _context.Yapeos.Remove(yapeo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YapeoExists(int id)
        {
            return _context.Yapeos.Any(e => e.IdYape == id);
        }
    }
}
