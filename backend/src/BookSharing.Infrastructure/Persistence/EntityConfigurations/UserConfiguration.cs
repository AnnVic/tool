using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .IsRequired();

        builder.Property(u => u.LastName)
            .IsRequired();

        builder.HasMany(u => u.UploadedBooks)
            .WithOne(b => b.Uploader)
            .HasForeignKey(b => b.UploaderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Assignments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired();
    }
}