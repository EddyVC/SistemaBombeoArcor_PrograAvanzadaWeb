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
    public class Detalleventa : ICRUD<data.Detalleventa>
    {
        private Repository<data.Detalleventa> repo;
        public Detalleventa(NDbContext dbContext)
        {
            repo = new Repository<data.Detalleventa>(dbContext);
        }
        public void Delete(data.Detalleventa t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Detalleventa> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Detalleventa>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Detalleventa GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Detalleventa> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Detalleventa t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Detalleventa t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
