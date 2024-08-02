using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public ContactoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Contactoes
        [HttpGet("ListarContactos")]
        public async Task<ActionResult<IEnumerable<object>>> GetContactos()
        {
            var contactos = await _context.Contactos
                .Select(c => new { c.IdContacto,c.Nombre, c.Numero })
                .ToListAsync();

            return contactos;
        }


        private string NormalizarCadena(string input)
        {
            // Convierte a minúsculas y elimina espacios al inicio y al final
            input = input.ToLowerInvariant().Trim();

            // Remueve tildes y diacríticos
            var normalizedString = input.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            var result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            // Condensa espacios múltiples a un solo espacio
            result = Regex.Replace(result, @"\s+", " ");

            return result.Trim(); // Asegura eliminar espacios al inicio y al final después de la normalización
        }


        [HttpGet("BuscarContactos")]
        public async Task<ActionResult<IEnumerable<object>>> GetContactoPorValor(string valor)
        {
            // Carga todos los contactos en memoria y selecciona solo el nombre y el número
            var todosLosContactos = await _context.Contactos
                .Select(c => new { c.IdContacto, c.Nombre, c.Numero })
                .ToListAsync();

            IEnumerable<object> contactosFiltrados;

            // Intenta convertir el valor a un número para buscar por número
            if (int.TryParse(valor, out int numero))
            {
                contactosFiltrados = todosLosContactos.Where(c => c.Numero == numero);
            }
            else
            {
                // Normaliza el valor de búsqueda para ignorar mayúsculas/minúsculas, tildes y espacios adicionales
                var valorNormalizado = NormalizarCadena(valor);

                // Si no es un número, busca por nombre normalizado en memoria
                contactosFiltrados = todosLosContactos
                    .Where(c => NormalizarCadena(c.Nombre).Contains(valorNormalizado));
            }

            if (!contactosFiltrados.Any())
            {
                return NotFound();
            }

            return contactosFiltrados.ToList();
        }





        // PUT: api/Contactoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            if (id != contacto.IdContacto)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
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

        // POST: api/Contactoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacto", new { id = contacto.IdContacto }, contacto);
        }

        // DELETE: api/Contactoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.IdContacto == id);
        }
    }
}
