using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public interface IRepositoryProducto : IRepository<data.Producto>
    {
        Task<IEnumerable<data.Producto>> GetAllAsync();
        Task<data.Producto> GetAllByIdAsync(int id);
    }
}
