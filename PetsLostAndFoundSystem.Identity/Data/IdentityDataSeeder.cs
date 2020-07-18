using System.Collections.Generic;
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
        private static IEnumerable<User> GetUsers()
            => new List<User>
            {
                new User {UserName = "NormalUser", Email = "normal@abv.bg"},
                new User {UserName = "AnotherUser", Email = "anotheruser@gmail.com"},
                new User {UserName = "SomeUser", Email = "someuser@gmail.com"}
            };

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
                    var moderatorRole = new IdentityRole(Constants.ModeratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);
                    await this.roleManager.CreateAsync(moderatorRole);

                    var adminUser = new User
                    {
                        UserName = "admin@admin.bg",
                        Email = "admin@admin.bg",
                        SecurityStamp = "SecurityStamp"
                    };

                    var moderatorUser = new User
                    {
                        UserName = "moderator@moderator.bg",
                        Email = "moderator@moderator.bg",
                        SecurityStamp = "SecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, "admin12");
                    await userManager.CreateAsync(moderatorUser, "moderator12");

                    await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);
                    await userManager.AddToRoleAsync(moderatorUser, Constants.ModeratorRoleName);
                })
                .GetAwaiter()
                .GetResult();

            if (this.userManager.Users.Any())
            {
                return;
            }

            foreach (var user in GetUsers())
            {
                userManager.CreateAsync(user, "admin12");
            }
        }
    }
}
