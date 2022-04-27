using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IProvinciasServices
    {
        void Insert(Provincia t);
        void Update(Provincia t);
        void Delete(Provincia t);
        IEnumerable<Provincia> GetAll();
        Provincia GetOneById(int id);
        Task<IEnumerable<Provincia>> GetAllAsync();
        Task<Provincia> GetOneByIdAsync(int id);
    }
}