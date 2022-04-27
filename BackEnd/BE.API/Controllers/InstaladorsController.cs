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
    public class InstaladorsController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public InstaladorsController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Instaladors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Instalador>>> GetInstaladors()
        {
            var res = await new BE.BS.Instalador(_context).GetAllAsync();
            List<models.Instalador> mapaAux = _mapper.Map<IEnumerable<data.Instalador>, IEnumerable<models.Instalador>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Instaladors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Instalador>> GetInstaladors(int id)
        {
            var intaladors = await new BE.BS.Instalador(_context).GetOneByIdAsync(id);

            if (intaladors == null)
            {
                return NotFound();
            }
            models.Instalador mapaAux = _mapper.Map<data.Instalador, models.Instalador>(intaladors);

            return mapaAux;
        }
        // PUT: api/Instaladors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstaladors(int id, models.Instalador intaladors)
        {
            if (id != intaladors.IdInstalador)
            {
                return BadRequest();
            }

            try
            {
                //Aqui es el casting al reves se recive el dato primero
                data.Instalador mapaAux = _mapper.Map<models.Instalador, data.Instalador>(intaladors);
                new BE.BS.Instalador(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!InstaladorsExists(id))
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
        public async Task<ActionResult<models.Instalador>> PostInstaladors(models.Instalador intaladors)
        {
            try
            {
                var mapAux = _mapper.Map<models.Instalador, data.Instalador>(intaladors);
                new BE.BS.Instalador(_context).Insert(mapAux);
            }
            catch (Exception ee)
            {
                BadRequest(ee);
            }

            return CreatedAtAction("GetInstaladors", new { id = intaladors.IdInstalador }, intaladors);
        }

        // DELETE: api/Instaladors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Instalador>> DeleteInstaladors(int id)
        {
            var intaladors = await new BE.BS.Instalador(_context).GetOneByIdAsync(id);
            if (intaladors == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Instalador(_context).Delete(intaladors);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Instalador mapaAux = _mapper.Map<data.Instalador, models.Instalador>(intaladors);

            return mapaAux;
        }

        private bool InstaladorsExists(int id)
        {
            return (new BE.BS.Instalador(_context).GetOneById(id) != null);
        }
    }
}
