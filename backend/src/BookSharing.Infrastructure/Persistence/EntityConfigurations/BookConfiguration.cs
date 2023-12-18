using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired()
            .HasMaxLength(70);

        builder.Property(b => b.Language)
            .IsRequired();

        builder.Property(b => b.UploaderId)
            .IsRequired();

        builder.Property(b => b.PublicationDate)
            .HasColumnType("date")
            .HasDefaultValueSql("CURRENT_DATE")
            .IsRequired();

        builder.HasOne(b => b.Uploader)
            .WithMany(u => u.UploadedBooks)
            .HasForeignKey(b => b.UploaderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Assignment)
            .WithOne(a => a.Book)
            .HasForeignKey<Book>(b => b.Id)
            .IsRequired(false);
    }
}