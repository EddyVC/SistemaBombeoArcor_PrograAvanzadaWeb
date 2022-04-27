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
    public class Venta : ICRUD<data.Venta>
    {
        private dal.Venta _dal;
        public Venta(NDbContext dbContext)
        {
            _dal = new dal.Venta(dbContext);
        }

        public void Delete(data.Venta t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Venta> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Venta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Venta GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Venta> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Venta t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Venta t)
        {
            _dal.Update(t);
        }
    }
}
