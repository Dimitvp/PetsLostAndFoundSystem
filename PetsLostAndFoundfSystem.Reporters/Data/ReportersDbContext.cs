using System.Reflection;

using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundfSystem.Reporters.Data.Models;

namespace PetsLostAndFoundfSystem.Reporters.Data
{
    public class ReportersDbContext : DbContext
    {
        public ReportersDbContext(DbContextOptions<ReportersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reporter> Reporters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }S
    }
}
