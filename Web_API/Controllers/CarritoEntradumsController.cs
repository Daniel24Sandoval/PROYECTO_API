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
    public class CarritoEntradumsController : ControllerBase
    {
        private readonly Soa24Context _context;

        public CarritoEntradumsController(Soa24Context context)
        {
            _context = context;
        }

        // GET: api/CarritoEntradums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoEntradum>>> GetCarritoEntrada()
        {
            return await _context.CarritoEntrada.ToListAsync();
        }

        // GET: api/CarritoEntradums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoEntradum>> GetCarritoEntradum(int id)
        {
            var carritoEntradum = await _context.CarritoEntrada.FindAsync(id);

            if (carritoEntradum == null)
            {
                return NotFound();
            }

            return carritoEntradum;
        }

        // PUT: api/CarritoEntradums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoEntradum(int id, CarritoEntradum carritoEntradum)
        {
            if (id != carritoEntradum.IdCarritoEntrada)
            {
                return BadRequest();
            }

            _context.Entry(carritoEntradum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoEntradumExists(id))
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

        // POST: api/CarritoEntradums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarritoEntradum>> PostCarritoEntradum(CarritoEntradum carritoEntradum)
        {
            _context.CarritoEntrada.Add(carritoEntradum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarritoEntradum", new { id = carritoEntradum.IdCarritoEntrada }, carritoEntradum);
        }

        // DELETE: api/CarritoEntradums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoEntradum(int id)
        {
            var carritoEntradum = await _context.CarritoEntrada.FindAsync(id);
            if (carritoEntradum == null)
            {
                return NotFound();
            }

            _context.CarritoEntrada.Remove(carritoEntradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoEntradumExists(int id)
        {
            return _context.CarritoEntrada.Any(e => e.IdCarritoEntrada == id);
        }
    }
}
