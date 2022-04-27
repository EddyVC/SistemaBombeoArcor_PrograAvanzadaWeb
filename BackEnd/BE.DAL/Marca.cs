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
    public class Marca : ICRUD<data.Marca>
    {
        private Repository<data.Marca> repo;
        public Marca(NDbContext dbContext)
        {
            repo = new Repository<data.Marca>(dbContext);
        }
        public void Delete(data.Marca t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Marca> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Marca>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Marca GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Marca> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Marca t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Marca t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

