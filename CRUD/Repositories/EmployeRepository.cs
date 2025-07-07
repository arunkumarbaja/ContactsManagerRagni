using CRUD.Data;
using CRUD.Models.Entites;
using CRUD.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Employe>> GetAllAsync()
        {
            var employeList = await _context.Employes
                .FromSqlRaw("EXEC GetAllEmployes")
                .ToListAsync();

            if (employeList == null || employeList.Count == 0)
            {
                throw new Exception("Employe list is empty");
            }

            return employeList;
        }

        public async Task<Employe> GetByIdAsync(int id)
        {
            var employeList = await _context.Employes
                .FromSqlRaw("EXEC GetEmployeById @Id = {0}", id)
                .ToListAsync(); 

            var employe = employeList.FirstOrDefault(); 

            if (employe == null)
            {
                throw new Exception("Employe not found");
            }

            return employe;
        }

        public async Task AddAsync(Employe employe)
        {
            var rowsEffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddEmploye @FirstName = {0}, @LastName = {1}, @Email = {2}, @Gender = {3}, @PhoneNumber = {4}, @JobTitle = {5}, @DepartmentId = {6}, @HireDate = {7}, @Salary = {8}, @IsActive = {9}",
                employe.FirstName, employe.LastName, employe.Email, (int)employe.Gender, employe.PhoneNumber,
                employe.JobTitle, employe.DepartmentId, employe.HireDate, employe.Salary, employe.IsActive);

            if (rowsEffected == 0)
            {
                throw new Exception("Failed to add an employe");
            }
        }

        public async Task UpdateAsync(Employe employe)
        {
            var rowsEffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC UpdateEmploye @Id = {0}, @FirstName = {1}, @LastName = {2}, @Email = {3}, @Gender = {4}, @PhoneNumber = {5}, @JobTitle = {6}, @DepartmentId = {7}, @HireDate = {8}, @Salary = {9}, @IsActive = {10}",
                employe.Id, employe.FirstName, employe.LastName, employe.Email, (int)employe.Gender, employe.PhoneNumber,
                employe.JobTitle, employe.DepartmentId, employe.HireDate, employe.Salary, employe.IsActive);

            if (rowsEffected == 0)
            {
                throw new Exception("Failed to update employe");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employe = await GetByIdAsync(id);
            if (employe == null)
            {
                return false;
            }

            var rowsEffected = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmploye @Id = {0}", id);

            return rowsEffected > 0;
        }
    }
}
