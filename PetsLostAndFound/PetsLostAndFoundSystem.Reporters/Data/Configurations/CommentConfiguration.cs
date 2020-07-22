using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Content)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.Reporter)
                .WithMany(u => u.Comments)
                .HasForeignKey(e => e.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(e => e.PostId);
        }
    }
}
