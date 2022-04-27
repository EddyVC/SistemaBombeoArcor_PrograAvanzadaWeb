using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL
{
    public class Provincia : ICRUD<data.Provincia>
    {
        private Repository<data.Provincia> repo;
        public Provincia(NDbContext dbContext)
        {
            repo = new Repository<data.Provincia>(dbContext);
        }
        public void Delete(data.Provincia t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Provincia> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Provincia>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Provincia GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Provincia> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Provincia t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Provincia t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

