using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Data.Models;

namespace PetsLostAndFoundSystem.Data
{
    public class PetsLostAndFoundDbContext : IdentityDbContext<User>
    {
        public PetsLostAndFoundDbContext(DbContextOptions<PetsLostAndFoundDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Shelter> Shelters { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Ad>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Ads)
                .HasForeignKey(a => a.AuthorId);

            builder
                .Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);

            builder
               .Entity<Shelter>()
               .HasOne(a => a.Author)
               .WithMany(u => u.Shelters)
               .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
