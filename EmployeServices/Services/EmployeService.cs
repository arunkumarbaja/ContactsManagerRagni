using CRUD.Models.Entites;
using CRUD.ServiceContracts;
using CRUD.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly IEmployeRepository _employeRepository;

        public EmployeService(IEmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }

        public async Task<List<Employe>> GetAllEmployes()
        {
            return await _employeRepository.GetAllAsync();
        }

        public async Task<Employe> GetEmployeByEmployeId(int id)
        {
            return await _employeRepository.GetByIdAsync(id);
        }

        public async Task AddEmployee(Employe employe)
        {
            await _employeRepository.AddAsync(employe);
        }

        public async Task UpdateEmploye(Employe employe)
        {
            await _employeRepository.UpdateAsync(employe);
        }

        public async Task<bool> DeleteEmploye(int id)
        {
            return await _employeRepository.DeleteAsync(id);
        }
    }
}
