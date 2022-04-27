using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public class RepositoryProducto : Repository<data.Producto>, IRepositoryProducto
    {
        public RepositoryProducto(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _db.Producto
                .Include(n => n.IdcategoriaNavigation)
                .Include(n => n.IdmarcaNavigation)
                .ToListAsync();
        }

        public async Task<Producto> GetAllByIdAsync(int id)
        {
            return await _db.Producto
                .Include(n => n.IdcategoriaNavigation)
                .Include(n => n.IdmarcaNavigation)
                .SingleOrDefaultAsync(n => n.Idproducto == id);
        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
