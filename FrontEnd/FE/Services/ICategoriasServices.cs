using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface ICategoriasServices
    {
        void Insert(Categoria t);
        void Update(Categoria t);
        void Delete(Categoria t);
        IEnumerable<Categoria> GetAll();
        Categoria GetOneById(int id);
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetOneByIdAsync(int id);
    }
}