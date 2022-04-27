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
    public class MarcasController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public MarcasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Marca>>> GetMarcas()
        {
            //return null;
            //return new BE.BS.Marcas(_context).GetAll().ToList();
            var res = new BE.BS.Marca(_context).GetAll();
            List<models.Marca> mapaAux = _mapper.Map<IEnumerable<data.Marca>, IEnumerable<models.Marca>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Marca>> GetMarcas(int id)
        {
            var marcas = new BE.BS.Marca(_context).GetOneById(id);

            if (marcas == null)
            {
                return NotFound();
            }
            models.Marca mapaAux = _mapper.Map<data.Marca, models.Marca>(marcas);
            return mapaAux;
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcas(int id, models.Marca marcas)
        {
            if (id != marcas.IdMarca)
            {
                return BadRequest();
            }

            try
            {
                data.Marca mapaAux = _mapper.Map<models.Marca, data.Marca>(marcas);
                new BE.BS.Marca(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!MarcasExists(id))
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

        // POST: api/Marcas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Marca>> PostMarcas(models.Marca marcas)
        {
            try
            {
                var mapAux = _mapper.Map<models.Marca, data.Marca>(marcas);
                new BE.BS.Marca(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetMarcas", new { id = marcas.IdMarca }, marcas);
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Marca>> DeleteMarcas(int id)
        {
            var marcas = new BE.BS.Marca(_context).GetOneById(id);
            if (marcas == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Marca(_context).Delete(marcas);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Marca, models.Marca>(marcas);
            return mapAux;
        }

        private bool MarcasExists(int id)
        {
            return (new BE.BS.Marca(_context).GetOneById(id) != null);
        }
    }
}
