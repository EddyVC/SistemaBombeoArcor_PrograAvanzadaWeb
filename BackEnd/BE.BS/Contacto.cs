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
    public class Contacto : ICRUD<data.Contacto>
    {
        private dal.Contacto _dal;
        public Contacto(NDbContext dbContext)
        {
            _dal = new dal.Contacto(dbContext);
        }
        public void Delete(data.Contacto t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Contacto> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Contacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Contacto GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Contacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Contacto t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Contacto t)
        {
            _dal.Update(t);
        }
    }
}
