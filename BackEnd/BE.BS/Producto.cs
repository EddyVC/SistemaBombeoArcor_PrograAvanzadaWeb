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
    public class Producto : ICRUD<data.Producto>
    {
        private dal.Producto _dal;
        public Producto(NDbContext dbContext)
        {
            _dal = new dal.Producto(dbContext);
        }
        public void Delete(data.Producto t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Producto GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Producto t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Producto t)
        {
            _dal.Update(t);
        }
    }
}
