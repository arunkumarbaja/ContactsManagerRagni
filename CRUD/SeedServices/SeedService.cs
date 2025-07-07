using CRUD.Data;
using CRUD.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace CRUD.SeedServices
{
    public  class SeedService
    {
       
        public async static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDBContext>(); 
            var userManager = scope.ServiceProvider.GetService<UserManager<User>>(); 
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            try
            {
                //ensuring whether database is created or not

                await context.Database.EnsureCreatedAsync();

                // adding roles
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                // 
                var AdminEmail = "admin@gmail.com";
                if (await userManager.FindByEmailAsync(AdminEmail) == null)
                {
                    var user = new User()
                    {
                        UserName = AdminEmail,
                        Email = AdminEmail,
                        NormalizedEmail = AdminEmail.ToUpper(),
                        NormalizedUserName = AdminEmail.ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var result = await userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new Exception("failed to create admin role");
                    }

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
{
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        var role = new IdentityRole
        {
            Name = roleName,
            NormalizedName = roleName.ToUpper()
        };

        var result = await roleManager.CreateAsync(role);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to create role {roleName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
    }
}
