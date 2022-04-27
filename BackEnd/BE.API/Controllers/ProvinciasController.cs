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
    public class ProvinciasController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ProvinciasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Provincias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Provincia>>> GetProvincias()
        {
            //return null;
            //return new BE.BS.Provincias(_context).GetAll().ToList();
            var res = new BE.BS.Provincia(_context).GetAll();
            List<models.Provincia> mapaAux = _mapper.Map<IEnumerable<data.Provincia>, IEnumerable<models.Provincia>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Provincia>> GetProvincias(int id)
        {
            var provincias = new BE.BS.Provincia(_context).GetOneById(id);

            if (provincias == null)
            {
                return NotFound();
            }
            models.Provincia mapaAux = _mapper.Map<data.Provincia, models.Provincia>(provincias);
            return mapaAux;
        }

        // PUT: api/Provincias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincias(int id, models.Provincia provincias)
        {
            if (id != provincias.IdProvincia)
            {
                return BadRequest();
            }

            try
            {
                data.Provincia mapaAux = _mapper.Map<models.Provincia, data.Provincia>(provincias);
                new BE.BS.Provincia(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!ProvinciasExists(id))
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

        // POST: api/Provincias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Provincia>> PostProvincias(models.Provincia provincias)
        {
            try
            {
                var mapAux = _mapper.Map<models.Provincia, data.Provincia>(provincias);
                new BE.BS.Provincia(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetProvincias", new { id = provincias.IdProvincia }, provincias);
        }

        // DELETE: api/Provincias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Provincia>> DeleteProvincias(int id)
        {
            var provincias = new BE.BS.Provincia(_context).GetOneById(id);
            if (provincias == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Provincia(_context).Delete(provincias);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Provincia, models.Provincia>(provincias);
            return mapAux;
        }

        private bool ProvinciasExists(int id)
        {
            return (new BE.BS.Provincia(_context).GetOneById(id) != null);
        }
    }
}
