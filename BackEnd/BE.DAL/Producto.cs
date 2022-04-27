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
    public class Producto : ICRUD<data.Producto>
    {
        private RepositoryProducto repo;
        public Producto(NDbContext dbContext)
        {
            repo = new RepositoryProducto(dbContext);
        }
        public void Delete(data.Producto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Producto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            return repo.GetAllByIdAsync(id);
        }

        public void Insert(data.Producto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Producto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

