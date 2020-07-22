using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Statistics.Data.Models;

namespace PetsLostAndFoundSystem.Statistics.Data.Configurations
{
    public class ReportViewConfiguration : IEntityTypeConfiguration<ReportView>
    {
        public void Configure(EntityTypeBuilder<ReportView> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasIndex(v => v.ReportId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}
