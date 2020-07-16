using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.MVC.Data.Models;
using System;

namespace PetsLostAndFoundSystem.MVC.Data.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Reporter)
                .WithMany(u => u.Pets)
                .HasForeignKey(e => e.ReporterId);
        }
    }
}
