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
    public class CategoriasController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Categoria>>> GetCategorias()
        {
            //return null;
            //return new BE.BS.Categorias(_context).GetAll().ToList();
            var res = new BE.BS.Categoria(_context).GetAll();
            List<models.Categoria> mapaAux = _mapper.Map<IEnumerable<data.Categoria>, IEnumerable<models.Categoria>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Categoria>> GetCategorias(int id)
        {
            var categorias = new BE.BS.Categoria(_context).GetOneById(id);

            if (categorias == null)
            {
                return NotFound();
            }
            models.Categoria mapaAux = _mapper.Map<data.Categoria, models.Categoria>(categorias);
            return mapaAux;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorias(int id, models.Categoria categorias)
        {
            if (id != categorias.Idcategoria)
            {
                return BadRequest();
            }

            try
            {
                data.Categoria mapaAux = _mapper.Map<models.Categoria, data.Categoria>(categorias);
                new BE.BS.Categoria(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!CategoriasExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Categoria>> PostCategorias(models.Categoria categorias)
        {
            try
            {
                var mapAux = _mapper.Map<models.Categoria, data.Categoria>(categorias);
                new BE.BS.Categoria(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCategorias", new { id = categorias.Idcategoria }, categorias);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Categoria>> DeleteCategorias(int id)
        {
            var categorias = new BE.BS.Categoria(_context).GetOneById(id);
            if (categorias == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Categoria(_context).Delete(categorias);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Categoria, models.Categoria>(categorias);
            return mapAux;
        }

        private bool CategoriasExists(int id)
        {
            return (new BE.BS.Categoria(_context).GetOneById(id) != null);
        }
    }
}
