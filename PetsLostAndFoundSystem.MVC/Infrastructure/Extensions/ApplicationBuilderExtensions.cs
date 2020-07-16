using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetsLostAndFoundSystem.MVC.Constants;
using PetsLostAndFoundSystem.MVC.Data;
using PetsLostAndFoundSystem.MVC.Data.Models;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.MVC.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PetsLostAndFoundDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
