using BE.DAL.DO.Interfaces;
using System;
using BE.DAL.EF;
using System.Collections.Generic;
using BE.DAL.Repository;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL
{
    public class Venta : ICRUD<data.Venta>
    {
        private Repository<data.Venta> repo;
        public Venta(NDbContext dbContext)
        {
            repo = new Repository<data.Venta>(dbContext);
        }
        public void Delete(data.Venta t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Venta> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Venta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Venta GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Venta> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Venta t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Venta t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
