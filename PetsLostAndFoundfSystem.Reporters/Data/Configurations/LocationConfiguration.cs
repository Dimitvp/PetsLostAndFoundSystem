using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
