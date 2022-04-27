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
    public class ProductosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ProductosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Producto>>> GetProductos()
        {
            var res = await new BE.BS.Producto(_context).GetAllAsync();
            List<models.Producto> mapaAux = _mapper.Map<IEnumerable<data.Producto>, IEnumerable<models.Producto>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Producto>> GetProductos(int id)
        {
            var productos = await new BE.BS.Producto(_context).GetOneByIdAsync(id);

            if (productos == null)
            {
                return NotFound();
            }
            models.Producto mapaAux = _mapper.Map<data.Producto, models.Producto>(productos);

            return mapaAux;
        }
        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, models.Producto productos)
        {
            if (id != productos.Idproducto)
            {
                return BadRequest();
            }

            try
            {
                //Aqui es el casting al reves se recive el dato primero
                data.Producto mapaAux = _mapper.Map<models.Producto, data.Producto>(productos);
                new BE.BS.Producto(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Producto>> PostProductos(models.Producto productos)
        {
            try
            {
                var mapAux = _mapper.Map<models.Producto, data.Producto>(productos);
                new BE.BS.Producto(_context).Insert(mapAux);
            }
            catch (Exception ee)
            {
                BadRequest(ee);
            }

            return CreatedAtAction("GetProductos", new { id = productos.Idproducto }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Producto>> DeleteProductos(int id)
        {
            var productos = await new BE.BS.Producto(_context).GetOneByIdAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Producto(_context).Delete(productos);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Producto mapaAux = _mapper.Map<data.Producto, models.Producto>(productos);

            return mapaAux;
        }

        private bool ProductosExists(int id)
        {
            return (new BE.BS.Producto(_context).GetOneById(id) != null);
        }
    }
}
