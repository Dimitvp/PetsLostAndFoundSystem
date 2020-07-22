using System.Reflection;

using Microsoft.EntityFrameworkCore;

using PetsLostAndFoundSystem.Publications.Data.Models;

namespace PetsLostAndFoundSystem.Publications.Data
{
    public class PublicationsDbContext : DbContext
    {
        public PublicationsDbContext(DbContextOptions<PublicationsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
