using System.Reflection;

using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Data
{
    public class ReportersDbContext : DbContext
    {
        public ReportersDbContext(DbContextOptions<ReportersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reporter> Reporters { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
