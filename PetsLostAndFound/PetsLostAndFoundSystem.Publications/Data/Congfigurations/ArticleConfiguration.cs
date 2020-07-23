using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsLostAndFoundSystem.Publications.Data.Models;

namespace PetsLostAndFoundSystem.Publications.Data.Congfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Title)
                .IsRequired();

            builder
                .Property(a => a.Content)
                .IsRequired();

            builder
                .Property(a => a.PublishDate)
                .IsRequired();

            builder
                .HasOne(a => a.Author)
                .WithMany(ar => ar.Articles)
                .HasForeignKey(ar => ar.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
