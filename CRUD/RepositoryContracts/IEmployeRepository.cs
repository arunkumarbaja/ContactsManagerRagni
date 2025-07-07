using CRUD.Models.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.RepositoryContracts
{
    public interface IEmployeRepository
    {
        Task<List<Employe>> GetAllAsync();
        Task<Employe> GetByIdAsync(int id);
        Task AddAsync(Employe employe);
        Task UpdateAsync(Employe employe);
        Task<bool> DeleteAsync(int id);
    }
}
