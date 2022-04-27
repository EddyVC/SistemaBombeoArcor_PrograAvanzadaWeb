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
    public class Detalleventa : ICRUD<data.Detalleventa>
    {
        private dal.Detalleventa _dal;
        public Detalleventa(NDbContext dbContext)
        {
            _dal = new dal.Detalleventa(dbContext);
        }
        public void Delete(data.Detalleventa t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Detalleventa> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Detalleventa>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Detalleventa GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Detalleventa> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Detalleventa t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Detalleventa t)
        {
            _dal.Update(t);
        }
    }
}