using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Publications.Data.Models;

using static PetsLostAndFoundSystem.Data.DataConstants.Common;

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
                .HasMaxLength(UserNameMaxLength);

            builder
                .Property(d => d.UserId)
                .IsRequired();


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
