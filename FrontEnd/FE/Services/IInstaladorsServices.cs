using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IInstaladorsServices
    {
        void Insert(Instalador t);
        void Update(Instalador t);
        void Delete(Instalador t);
        IEnumerable<Instalador> GetAll();
        Instalador GetOneById(int id);
        Task<IEnumerable<Instalador>> GetAllAsync();
        Task<Instalador> GetOneByIdAsync(int id);
    }
}
