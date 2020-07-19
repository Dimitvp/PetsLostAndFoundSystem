using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetsLostAndFoundSystem.Reporters.Data.Models;

using static PetsLostAndFoundSystem.Data.DataConstants.Common;

namespace PetsLostAndFoundSystem.Reporters.Data.Configurations
{
    public class ReporterConfigurations : IEntityTypeConfiguration<Reporter>
    {
        public void Configure(EntityTypeBuilder<Reporter> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(UserNameMaxLength);

            builder
                .Property(r => r.PhoneNumber)
                .IsRequired()
                .HasMaxLength(MaxPhoneNumberLength);

            builder
                .Property(r => r.UserId)
                .IsRequired();

            builder
                .HasMany(r => r.Reports)
                .WithOne(re => re.Reporter)
                .HasForeignKey(re => re.ReporterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(r => r.Pets)
                .WithOne(p => p.Reporter)
                .HasForeignKey(p => p.ReporterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(r => r.Comments)
                .WithOne(c => c.Reporter)
                .HasForeignKey(c => c.ReporterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
