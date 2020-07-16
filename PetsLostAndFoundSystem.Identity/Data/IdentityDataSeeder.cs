using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using PetsLostAndFoundSystem.Identity.Data.Models;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Identity.Data
{
    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(Constants.AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new User
                    {
                        UserName = "admin@admin.bg",
                        Email = "admin@admin.bg",
                        SecurityStamp = "SecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, "admin12");

                    await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
