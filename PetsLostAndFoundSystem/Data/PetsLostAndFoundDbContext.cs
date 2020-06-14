using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Data.Models;
using System.Reflection;

namespace PetsLostAndFoundSystem.Data
{
    public class PetsLostAndFoundDbContext : IdentityDbContext<User>
    {
        public PetsLostAndFoundDbContext(DbContextOptions<PetsLostAndFoundDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Reporter> Reporters { get; set; }

        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
