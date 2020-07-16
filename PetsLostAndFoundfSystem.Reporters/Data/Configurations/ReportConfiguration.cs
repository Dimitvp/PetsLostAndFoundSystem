using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Reporters.Data.Models;

using static PetsLostAndFoundSystem.Data.DataConstants.Common;

namespace PetsLostAndFoundSystem.Reporters.Data.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                 .HasKey(c => c.Id);

            builder.Property(e => e.Status).IsRequired();

            builder.HasOne(r => r.Reporter)
                .WithMany(re => re.Reports)
                .HasForeignKey(re => re.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Pet)
                .WithMany(p => p.Reports)
                .HasForeignKey(e => e.PetId);

            builder.HasOne(r => r.Location)
                .WithMany(l => l.Reports)
                .HasForeignKey(r => r.LocationId);
           
            builder
                .Property(r => r.ImagesLinksPost)
                .IsRequired()
                .HasMaxLength(PicUrlMaxLength);

            builder
                .Property(r => r.LostDate )
                .IsRequired();

            builder
                .Property(r => r.IsApproved)
                .IsRequired();
        }
    }
}
