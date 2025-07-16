using CRUD.Enum;
using CRUD.Models.Entites;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Employe> Employes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employe>().HasData(
                new Employe { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Gender = Gender.Male, PhoneNumber = "1234567890", JobTitle = "Software Engineer", DepartmentId = 1, HireDate = new DateTime(2020, 01, 15), Salary = 75000, IsActive = true },
                new Employe { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Gender = Gender.Female, PhoneNumber = "2345678901", JobTitle = "QA Analyst", DepartmentId = 2, HireDate = new DateTime(2019, 05, 10), Salary = 65000, IsActive = true },
                new Employe { Id = 3, FirstName = "Robert", LastName = "Brown", Email = "robert.brown@example.com", Gender = Gender.Male, PhoneNumber = "3456789012", JobTitle = "Project Manager", DepartmentId = 3, HireDate = new DateTime(2018, 09, 20), Salary = 90000, IsActive = true },
                new Employe { Id = 4, FirstName = "Emily", LastName = "Clark", Email = "emily.clark@example.com", Gender = Gender.Female, PhoneNumber = "4567890123", JobTitle = "UX Designer", DepartmentId = 4, HireDate = new DateTime(2021, 03, 12), Salary = 70000, IsActive = true },
                new Employe { Id = 5, FirstName = "Daniel", LastName = "Lee", Email = "daniel.lee@example.com", Gender = Gender.Male, PhoneNumber = "5678901234", JobTitle = "DevOps Engineer", DepartmentId = 5, HireDate = new DateTime(2022, 07, 01), Salary = 80000, IsActive = true },
                new Employe { Id = 6, FirstName = "Olivia", LastName = "Walker", Email = "olivia.walker@example.com", Gender = Gender.Female, PhoneNumber = "6789012345", JobTitle = "HR Manager", DepartmentId = 6, HireDate = new DateTime(2017, 02, 18), Salary = 85000, IsActive = false },
                new Employe { Id = 7, FirstName = "David", LastName = "King", Email = "david.king@example.com", Gender = Gender.Male, PhoneNumber = "7890123456", JobTitle = "Network Engineer", DepartmentId = 7, HireDate = new DateTime(2020, 11, 05), Salary = 72000, IsActive = true },
                new Employe { Id = 8, FirstName = "Sophia", LastName = "Allen", Email = "sophia.allen@example.com", Gender = Gender.Female, PhoneNumber = "8901234567", JobTitle = "System Analyst", DepartmentId = 8, HireDate = new DateTime(2016, 04, 25), Salary = 69000, IsActive = true },
                new Employe { Id = 9, FirstName = "James", LastName = "Scott", Email = "james.scott@example.com", Gender = Gender.Male, PhoneNumber = "9012345678", JobTitle = "IT Support", DepartmentId = 9, HireDate = new DateTime(2023, 01, 01), Salary = 55000, IsActive = true },
                new Employe { Id = 10, FirstName = "Grace", LastName = "Green", Email = "grace.green@example.com", Gender = Gender.Female, PhoneNumber = "0123456789", JobTitle = "Security Analyst", DepartmentId = 10, HireDate = new DateTime(2022, 08, 08), Salary = 78000, IsActive = true },

                new Employe { Id = 11, FirstName = "Aaron", LastName = "Young", Email = "aaron.young@example.com", Gender = Gender.Male, PhoneNumber = "1231231234", JobTitle = "Frontend Developer", DepartmentId = 1, HireDate = new DateTime(2021, 10, 10), Salary = 73000, IsActive = true },
                new Employe { Id = 12, FirstName = "Zoe", LastName = "Hill", Email = "zoe.hill@example.com", Gender = Gender.Female, PhoneNumber = "2342342345", JobTitle = "Backend Developer", DepartmentId = 2, HireDate = new DateTime(2021, 09, 09), Salary = 77000, IsActive = true },
                new Employe { Id = 13, FirstName = "Ethan", LastName = "Wright", Email = "ethan.wright@example.com", Gender = Gender.Male, PhoneNumber = "3453453456", JobTitle = "Database Admin", DepartmentId = 3, HireDate = new DateTime(2015, 03, 03), Salary = 88000, IsActive = false },
                new Employe { Id = 14, FirstName = "Lily", LastName = "Lopez", Email = "lily.lopez@example.com", Gender = Gender.Female, PhoneNumber = "4564564567", JobTitle = "Mobile Developer", DepartmentId = 4, HireDate = new DateTime(2018, 06, 06), Salary = 71000, IsActive = true },
                new Employe { Id = 15, FirstName = "Henry", LastName = "Adams", Email = "henry.adams@example.com", Gender = Gender.Male, PhoneNumber = "5675675678", JobTitle = "Business Analyst", DepartmentId = 5, HireDate = new DateTime(2019, 12, 12), Salary = 76000, IsActive = true },
                new Employe { Id = 16, FirstName = "Ella", LastName = "Baker", Email = "ella.baker@example.com", Gender = Gender.Female, PhoneNumber = "6786786789", JobTitle = "Tech Lead", DepartmentId = 6, HireDate = new DateTime(2017, 07, 07), Salary = 98000, IsActive = true },
                new Employe { Id = 17, FirstName = "Logan", LastName = "Nelson", Email = "logan.nelson@example.com", Gender = Gender.Male, PhoneNumber = "7897897890", JobTitle = "Architect", DepartmentId = 7, HireDate = new DateTime(2014, 11, 11), Salary = 102000, IsActive = true },
                new Employe { Id = 18, FirstName = "Chloe", LastName = "Carter", Email = "chloe.carter@example.com", Gender = Gender.Female, PhoneNumber = "8908908901", JobTitle = "Consultant", DepartmentId = 8, HireDate = new DateTime(2020, 05, 05), Salary = 85000, IsActive = true },
                new Employe { Id = 19, FirstName = "Lucas", LastName = "Mitchell", Email = "lucas.mitchell@example.com", Gender = Gender.Male, PhoneNumber = "9019019012", JobTitle = "Trainer", DepartmentId = 9, HireDate = new DateTime(2023, 02, 02), Salary = 60000, IsActive = true },
                new Employe { Id = 20, FirstName = "Ava", LastName = "Perez", Email = "ava.perez@example.com", Gender = Gender.Female, PhoneNumber = "0120120123", JobTitle = "Content Strategist", DepartmentId = 10, HireDate = new DateTime(2023, 04, 04), Salary = 67000, IsActive = true },
                new Employe { Id = 21, FirstName = "Ava", LastName = "Perez", Email = "ava.perez@example.com", Gender = Gender.Female, PhoneNumber = "0120120123", JobTitle = "Content Strategist", DepartmentId = 10, HireDate = new DateTime(2023, 04, 04), Salary = 67000, IsActive = true }
            );
            modelBuilder.Entity<LoginViewModel>().HasNoKey();
            modelBuilder.Entity<RegisterViewModel>().HasNoKey();
            modelBuilder.Entity<VerifyEmailViewModel>().HasNoKey();
            modelBuilder.Entity<ChangePasswordViewModel>().HasNoKey();
        }
        public DbSet<CRUD.Models.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<CRUD.Models.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<CRUD.Models.ViewModels.VerifyEmailViewModel> VerifyEmailViewModel { get; set; } = default!;
        public DbSet<CRUD.Models.ViewModels.ChangePasswordViewModel> ChangePasswordViewModel { get; set; } = default!;
    }
}
