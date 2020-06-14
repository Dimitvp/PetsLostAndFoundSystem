using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Constants;
using PetsLostAndFoundSystem.Data.Models;
using System;

namespace PetsLostAndFoundSystem.Data.Configurations
{
    public class ReporterConfiguration : IEntityTypeConfiguration<Reporter>
    {
        public void Configure(EntityTypeBuilder<Reporter> builder)
        {
            builder
                     .HasKey(a => a.Id);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(DataConstants.UserNameMaxLength);

            builder
                .HasOne(a => a.User)
                .WithOne(u => u.Reporter)
                .HasForeignKey<Reporter>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(r => r.Reports )
                .WithOne(re => re.Reporter)
                .HasForeignKey(re => re.ReporterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(r => r.Shelters)
                .WithOne(s => s.Reporter)
                .HasForeignKey(s => s.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
