using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly Soa24Context _context;

        public EmpresasController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
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




        [HttpGet("Listar Empresas - Pago Servicio/{nombre}")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmpresaPS(string nombre)
        {
            // Primero, obtén todas las empresas de la base de datos
            var todasLasEmpresas = await _context.Empresas.ToListAsync();

            // Normaliza el nombre de búsqueda para ignorar mayúsculas/minúsculas y tildes
            var nombreNormalizado = NormalizarCadena(nombre);

            // Ahora, filtra en memoria las empresas que coincidan con el criterio de búsqueda
            // y selecciona solo el ID y el nombre de cada empresa
            var empresasFiltradas = todasLasEmpresas
                                    .Where(e => NormalizarCadena(e.Nombre).Contains(nombreNormalizado))
                                    .Select(e => new { e.IdEmpresa, e.Nombre }) // Selecciona solo el ID y el nombre
                                    .ToList();

            if (!empresasFiltradas.Any())
            {
                return NotFound();
            }

            return empresasFiltradas;
        }



        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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

        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.IdEmpresa }, empresa);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.IdEmpresa == id);
        }
    }
}
