using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IVentasServices
    {
        void Insert(Venta t);
        void Update(Venta t);
        void Delete(Venta t);
        IEnumerable<Venta> GetAll();
        Venta GetOneById(int id);
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<Venta> GetOneByIdAsync(int id);
    }
}

