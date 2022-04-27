using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleventasController : ControllerBase
    {
        private readonly BombeoPruebaContext _context;

        public DetalleventasController(BombeoPruebaContext context)
        {
            _context = context;
        }

        // GET: api/Detalleventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalleventa>>> GetDetalleventa()
        {
            return await _context.Detalleventa.ToListAsync();
        }

        // GET: api/Detalleventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalleventa>> GetDetalleventa(int id)
        {
            var detalleventa = await _context.Detalleventa.FindAsync(id);

            if (detalleventa == null)
            {
                return NotFound();
            }

            return detalleventa;
        }

        // PUT: api/Detalleventas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleventa(int id, Detalleventa detalleventa)
        {
            if (id != detalleventa.Iddetalleventa)
            {
                return BadRequest();
            }

            _context.Entry(detalleventa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleventaExists(id))
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

        // POST: api/Detalleventas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Detalleventa>> PostDetalleventa(Detalleventa detalleventa)
        {
            _context.Detalleventa.Add(detalleventa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleventa", new { id = detalleventa.Iddetalleventa }, detalleventa);
        }

        // DELETE: api/Detalleventas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detalleventa>> DeleteDetalleventa(int id)
        {
            var detalleventa = await _context.Detalleventa.FindAsync(id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            _context.Detalleventa.Remove(detalleventa);
            await _context.SaveChangesAsync();

            return detalleventa;
        }

        private bool DetalleventaExists(int id)
        {
            return _context.Detalleventa.Any(e => e.Iddetalleventa == id);
        }
    }
}
