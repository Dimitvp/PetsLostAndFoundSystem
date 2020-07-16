using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.MVC.Constants;
using PetsLostAndFoundSystem.MVC.Data.Models;

namespace PetsLostAndFoundSystem.MVC.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                    .HasKey(a => a.Id);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(DataConstants.UserNameMaxLength);

            builder
                .HasOne(a => a.User)
                .WithOne(u => u.Author)
                .HasForeignKey<Author>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(au => au.Articles)
                .WithOne(ar => ar.Author) 
                .HasForeignKey(ar => ar.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(au => au.Shelters)
                .WithOne(ar => ar.Author)
                .HasForeignKey(ar => ar.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
