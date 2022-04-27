using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IMarcasServices
    {
        void Insert(Marca t);
        void Update(Marca t);
        void Delete(Marca t);
        IEnumerable<Marca> GetAll();
        Marca GetOneById(int id);
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca> GetOneByIdAsync(int id);
    }
}