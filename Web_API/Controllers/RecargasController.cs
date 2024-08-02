using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;
using Web_API.Transfer;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecargasController : ControllerBase
    {
        private readonly Soa24Context _context;

        public RecargasController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Recargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recarga>>> GetRecargas()
        {
            return await _context.Recargas.ToListAsync();
        }

        // GET: api/Recargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recarga>> GetRecarga(int id)
        {
            var recarga = await _context.Recargas.FindAsync(id);

            if (recarga == null)
            {
                return NotFound();
            }

            return recarga;
        }

        // PUT: api/Recargas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecarga(int id, Recarga recarga)
        {
            if (id != recarga.IdRecarga)
            {
                return BadRequest();
            }

            _context.Entry(recarga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecargaExists(id))
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

        // POST: api/Recargas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recarga>> PostRecarga(Recarga recarga)
        {
            _context.Recargas.Add(recarga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecarga", new { id = recarga.IdRecarga }, recarga);
        }

        // DELETE: api/Recargas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecarga(int id)
        {
            var recarga = await _context.Recargas.FindAsync(id);
            if (recarga == null)
            {
                return NotFound();
            }

            _context.Recargas.Remove(recarga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecargaExists(int id)
        {
            return _context.Recargas.Any(e => e.IdRecarga == id);
        }

        // POST: api/Recargas/Recarga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Recarga")]
        public async Task<ActionResult<RecargaResponseDTO>> Recarga(RecargaDTO recargaDto)
        {
            // 
            var contacto = await _context.Contactos.FindAsync(recargaDto.IdContacto);
            

            // Verificar que el usuario existe
            var usuario = await _context.Usuarios.FindAsync(recargaDto.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El usuario no existe.");
            }

            // Verificar que el usuario tiene saldo suficiente en su cuenta
            var cuenta = await _context.Cuenta.FirstOrDefaultAsync(c => c.IdUsuario == recargaDto.IdUsuario);
            if (cuenta == null || cuenta.Saldo < recargaDto.Monto)
            {
                return BadRequest("El usuario no tiene saldo suficiente en su cuenta.");
            }

            // Verificar que el IdOperadora del contacto coincide con el IdOperadora ingresado
            if (contacto.IdOperadora != recargaDto.IdOperadora)
            {
                return BadRequest("La operadora del contacto no coincide con la operadora ingresada.");
            }

            // Si todas las verificaciones pasan, agregar la recarga
            var recarga = new Recarga
            {
                IdContacto = recargaDto.IdContacto ?? 0, 
                IdUsuario = recargaDto.IdUsuario ?? 0,   
                Monto = recargaDto.Monto ?? 0m,         
             };

            _context.Recargas.Add(recarga);
            await _context.SaveChangesAsync();

            var recargaResponse = new RecargaResponseDTO
            {
                IdRecarga = recarga.IdRecarga ,
                IdContacto = recarga.IdContacto,
                IdUsuario = recarga.IdUsuario,
                Monto = recarga.Monto,
                
            };

            return CreatedAtAction("GetRecarga", new { id = recargaResponse.IdRecarga }, recargaResponse);
        }
    }
}
    
 
