using CRUD.Models.Entites;

namespace CRUD.ServiceContracts
{
    public interface IEmployeService
    {
        Task<List<Employe>> GetAllEmployes();
        Task<Employe> GetEmployeByEmployeId(int id);
        Task AddEmployee(Employe employe);
        Task UpdateEmploye(Employe employe);
        Task<bool> DeleteEmploye(int id);
    }

}
