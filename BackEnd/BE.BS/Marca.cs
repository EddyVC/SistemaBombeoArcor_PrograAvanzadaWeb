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
    public class Marca : ICRUD<data.Marca>
    {
        private dal.Marca _dal;
        public Marca(NDbContext dbContext)
        {
            _dal = new dal.Marca(dbContext);
        }
        public void Delete(data.Marca t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Marca> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Marca>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Marca GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Marca> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Marca t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Marca t)
        {
            _dal.Update(t);
        }
    }
}
