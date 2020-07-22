using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Publications.Data.Models;

using static PetsLostAndFoundSystem.Data.DataConstants.Common;

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
                .HasMaxLength(UserNameMaxLength);

            builder.Property(d => d.UserId)
                .IsRequired();


            builder.HasOne(s => s.Author)
               .WithMany(a => a.Shelters)
               .HasForeignKey(a => a.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
