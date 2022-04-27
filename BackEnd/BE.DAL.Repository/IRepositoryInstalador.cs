using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public interface IRepositoryInstalador : IRepository<data.Instalador>
    {
        Task<IEnumerable<data.Instalador>> GetAllAsync();
        Task<data.Instalador> GetAllByIdAsync(int id);
    }
}
