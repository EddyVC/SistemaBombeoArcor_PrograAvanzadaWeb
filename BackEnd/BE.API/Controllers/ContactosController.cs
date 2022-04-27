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
    public class ContactosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ContactosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Contacto>>> GetContactos()
        {
            //return null;
            //return new BE.BS.Contactos(_context).GetAll().ToList();
            var res = new BE.BS.Contacto(_context).GetAll();
            List<models.Contacto> mapaAux = _mapper.Map<IEnumerable<data.Contacto>, IEnumerable<models.Contacto>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Contactos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Contacto>> GetContactos(int id)
        {
            var contactos = new BE.BS.Contacto(_context).GetOneById(id);

            if (contactos == null)
            {
                return NotFound();
            }
            models.Contacto mapaAux = _mapper.Map<data.Contacto, models.Contacto>(contactos);
            return mapaAux;
        }

        // PUT: api/Contactos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactos(int id, models.Contacto contactos)
        {
            if (id != contactos.Idcontacto)
            {
                return BadRequest();
            }

            try
            {
                data.Contacto mapaAux = _mapper.Map<models.Contacto, data.Contacto>(contactos);
                new BE.BS.Contacto(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!ContactosExists(id))
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

        // POST: api/Contactos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Contacto>> PostContactos(models.Contacto contactos)
        {
            try
            {
                var mapAux = _mapper.Map<models.Contacto, data.Contacto>(contactos);
                new BE.BS.Contacto(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetContactos", new { id = contactos.Idcontacto }, contactos);
        }

        // DELETE: api/Contactos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Contacto>> DeleteContactos(int id)
        {
            var contactos = new BE.BS.Contacto(_context).GetOneById(id);
            if (contactos == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Contacto(_context).Delete(contactos);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Contacto, models.Contacto>(contactos);
            return mapAux;
        }

        private bool ContactosExists(int id)
        {
            return (new BE.BS.Contacto(_context).GetOneById(id) != null);
        }
    }
}
