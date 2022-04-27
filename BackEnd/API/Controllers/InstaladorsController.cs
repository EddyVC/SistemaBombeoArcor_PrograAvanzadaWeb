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
    public class InstaladorsController : ControllerBase
    {
        private readonly BombeoPruebaContext _context;

        public InstaladorsController(BombeoPruebaContext context)
        {
            _context = context;
        }

        // GET: api/Instaladors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalador>>> GetInstalador()
        {
            return await _context.Instalador.ToListAsync();
        }

        // GET: api/Instaladors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalador>> GetInstalador(int id)
        {
            var instalador = await _context.Instalador.FindAsync(id);

            if (instalador == null)
            {
                return NotFound();
            }

            return instalador;
        }

        // PUT: api/Instaladors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalador(int id, Instalador instalador)
        {
            if (id != instalador.IdInstalador)
            {
                return BadRequest();
            }

            _context.Entry(instalador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstaladorExists(id))
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

        // POST: api/Instaladors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Instalador>> PostInstalador(Instalador instalador)
        {
            _context.Instalador.Add(instalador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstalador", new { id = instalador.IdInstalador }, instalador);
        }

        // DELETE: api/Instaladors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instalador>> DeleteInstalador(int id)
        {
            var instalador = await _context.Instalador.FindAsync(id);
            if (instalador == null)
            {
                return NotFound();
            }

            _context.Instalador.Remove(instalador);
            await _context.SaveChangesAsync();

            return instalador;
        }

        private bool InstaladorExists(int id)
        {
            return _context.Instalador.Any(e => e.IdInstalador == id);
        }
    }
}
