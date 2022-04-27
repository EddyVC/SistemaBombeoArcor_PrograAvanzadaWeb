using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IProductosServices
    {
        void Insert(Producto t);
        void Update(Producto t);
        void Delete(Producto t);
        IEnumerable<Producto> GetAll();
        Producto GetOneById(int id);
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetOneByIdAsync(int id);
    }
}
