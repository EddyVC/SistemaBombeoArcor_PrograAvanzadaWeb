using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IContactosServices
    {
        void Insert(Contacto t);
        void Update(Contacto t);
        void Delete(Contacto t);
        IEnumerable<Contacto> GetAll();
        Contacto GetOneById(int id);
        Task<IEnumerable<Contacto>> GetAllAsync();
        Task<Contacto> GetOneByIdAsync(int id);
    }
}