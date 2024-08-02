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
    public class CategoriaEventoesController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CategoriaEventoesController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/CategoriaEventoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEvento>>> GetCategoriaEventos()
        {
            return await _context.CategoriaEventos.ToListAsync();
        }

        // GET: api/CategoriaEventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEvento>> GetCategoriaEvento(int id)
        {
            var categoriaEvento = await _context.CategoriaEventos.FindAsync(id);

            if (categoriaEvento == null)
            {
                return NotFound();
            }

            return categoriaEvento;
        }

        // PUT: api/CategoriaEventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaEvento(int id, CategoriaEvento categoriaEvento)
        {
            if (id != categoriaEvento.IdCategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoriaEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaEventoExists(id))
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

        // POST: api/CategoriaEventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaEvento>> PostCategoriaEvento(CategoriaEvento categoriaEvento)
        {
            _context.CategoriaEventos.Add(categoriaEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaEvento", new { id = categoriaEvento.IdCategoria }, categoriaEvento);
        }

        // DELETE: api/CategoriaEventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaEvento(int id)
        {
            var categoriaEvento = await _context.CategoriaEventos.FindAsync(id);
            if (categoriaEvento == null)
            {
                return NotFound();
            }

            _context.CategoriaEventos.Remove(categoriaEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaEventoExists(int id)
        {
            return _context.CategoriaEventos.Any(e => e.IdCategoria == id);
        }
    }
}
