using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Instalador : ICRUD<data.Instalador>
    {
        private dal.Instalador _dal;
        public Instalador(NDbContext dbContext)
        {
            _dal = new dal.Instalador(dbContext);
        }
        public void Delete(data.Instalador t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Instalador> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Instalador>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Instalador GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Instalador> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Instalador t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Instalador t)
        {
            _dal.Update(t);
        }
    }
}
