using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.MVC.Constants;
using PetsLostAndFoundSystem.MVC.Data.Models;
using System;

namespace PetsLostAndFoundSystem.MVC.Data.Configurations
{
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder
                 .HasKey(c => c.Id);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(DataConstants.UserNameMaxLength);

            builder.HasOne(s => s.Reporter)
                .WithMany(re => re.Shelters)
                .HasForeignKey(re => re.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Author)
               .WithMany(a => a.Shelters)
               .HasForeignKey(a => a.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
