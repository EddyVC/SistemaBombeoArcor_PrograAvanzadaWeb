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
    public class Provincia : ICRUD<data.Provincia>
    {
        private dal.Provincia _dal;
        public Provincia(NDbContext dbContext)
        {
            _dal = new dal.Provincia(dbContext);
        }
        public void Delete(data.Provincia t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Provincia> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Provincia>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Provincia GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Provincia> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Provincia t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Provincia t)
        {
            _dal.Update(t);
        }
    }
}
