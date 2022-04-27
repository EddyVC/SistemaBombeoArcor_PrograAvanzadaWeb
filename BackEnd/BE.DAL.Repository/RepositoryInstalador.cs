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
    public class RepositoryInstalador : Repository<data.Instalador>, IRepositoryInstalador
    {
        public RepositoryInstalador(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Instalador>> GetAllAsync()
        {
            return await _db.Instalador.Include(n => n.IdProvinciaNavigation).ToListAsync();
        }

        public async Task<Instalador> GetAllByIdAsync(int id)
        {
            return await _db.Instalador.Include(n => n.IdProvinciaNavigation).SingleOrDefaultAsync(n => n.IdInstalador == id);
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
