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
    public class VentasController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public VentasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Venta>>> GetVenta()
        {
            var res = new BE.BS.Venta(_context).GetAll();
            List<models.Venta> mapaAux = _mapper.Map<IEnumerable<data.Venta>, IEnumerable<models.Venta>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Venta>> GetVenta(int id)
        {
            var ventas = new BE.BS.Venta(_context).GetOneById(id);

            if (ventas == null)
            {
                return NotFound();
            }
            models.Venta mapaAux = _mapper.Map<data.Venta, models.Venta>(ventas);
            return mapaAux;
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, models.Venta ventas)
        {
            if (id != ventas.Idventa)
            {
                return BadRequest();
            }

            try
            {
                data.Venta mapaAux = _mapper.Map<models.Venta, data.Venta>(ventas);
                new BE.BS.Venta(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!VentaExists(id))
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

        // POST: api/Ventas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Venta>> PostVenta(models.Venta venta)
        {
            try
            {
                var mapAux = _mapper.Map<models.Venta, data.Venta>(venta);
                new BE.BS.Venta(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetVenta", new { id = venta.Idventa }, venta);
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Venta>> DeleteVenta(int id)
        {
            var ventas = new BE.BS.Venta(_context).GetOneById(id);
            if (ventas == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Venta(_context).Delete(ventas);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Venta, models.Venta>(ventas);
            return mapAux;
        }

        private bool VentaExists(int id)
        {
            return (new BE.BS.Venta(_context).GetOneById(id) != null);
        }
    }
}

