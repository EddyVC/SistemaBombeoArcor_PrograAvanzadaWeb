using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IDetalleventasServices
    {
        void Insert(Detalleventa t);
        void Update(Detalleventa t);
        void Delete(Detalleventa t);
        IEnumerable<Detalleventa> GetAll();
        Detalleventa GetOneById(int id);
        Task<IEnumerable<Detalleventa>> GetAllAsync();
        Task<Detalleventa> GetOneByIdAsync(int id);
    }
}

