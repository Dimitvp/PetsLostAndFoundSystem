using System.Reflection;

using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Data;
using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Data
{
    public class ReportersDbContext : MessageDbContext
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

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
