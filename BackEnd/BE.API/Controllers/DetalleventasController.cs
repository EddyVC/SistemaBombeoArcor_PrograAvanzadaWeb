using AutoMapper;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleventasController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public DetalleventasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Detalleventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Detalleventa>>> GetDetalleventa()
        {
            //return null;
            //return new BE.BS.Categorias(_context).GetAll().ToList();
            var res = new BE.BS.Detalleventa(_context).GetAll();
            List<models.Detalleventa> mapaAux = _mapper.Map<IEnumerable<data.Detalleventa>, IEnumerable<models.Detalleventa>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Detalleventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Detalleventa>> GetDetalleventa(int id)
        {
            var detalleventas = new BE.BS.Detalleventa(_context).GetOneById(id);

            if (detalleventas == null)
            {
                return NotFound();
            }
            models.Detalleventa mapaAux = _mapper.Map<data.Detalleventa, models.Detalleventa>(detalleventas);
            return mapaAux;
        }

        // PUT: api/Detalleventas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleventa(int id, models.Detalleventa detalleventa)
        {
            if (id != detalleventa.Iddetalleventa)
            {
                return BadRequest();
            }

            try
            {
                data.Detalleventa mapaAux = _mapper.Map<models.Detalleventa, data.Detalleventa>(detalleventa);
                new BE.BS.Detalleventa(_context).Update(mapaAux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.Detalleventa>> PostDetalleventa(models.Detalleventa detalleventa)
        {
            try
            {
                var mapAux = _mapper.Map<models.Detalleventa, data.Detalleventa>(detalleventa);
                new BE.BS.Detalleventa(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetDetalleventas", new { id = detalleventa.Iddetalleventa }, detalleventa);
        }

        // DELETE: api/Detalleventas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Detalleventa>> DeleteDetalleventa(int id)
        {
            var detalleventas = new BE.BS.Detalleventa(_context).GetOneById(id);
            if (detalleventas == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Detalleventa(_context).Delete(detalleventas);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Detalleventa, models.Detalleventa>(detalleventas);
            return mapAux;
        }

        private bool DetalleventaExists(int id)
        {
            return (new BE.BS.Detalleventa(_context).GetOneById(id) != null);
        }
    }
}
