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
    public class Categoria : ICRUD<data.Categoria>
    {
        private Repository<data.Categoria> repo;
        public Categoria(NDbContext dbContext)
        {
            repo = new Repository<data.Categoria>(dbContext);
        }
        public void Delete(data.Categoria t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Categoria> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Categoria>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Categoria GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Categoria> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Categoria t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Categoria t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

