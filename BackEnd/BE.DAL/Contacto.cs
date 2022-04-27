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
    public class Contacto : ICRUD<data.Contacto>
    {
        private Repository<data.Contacto> repo;
        public Contacto(NDbContext dbContext)
        {
            repo = new Repository<data.Contacto>(dbContext);
        }
        public void Delete(data.Contacto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Contacto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Contacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Contacto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Contacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Contacto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Contacto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}