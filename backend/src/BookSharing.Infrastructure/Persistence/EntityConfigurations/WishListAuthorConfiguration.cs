using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.EntityConfigurations;

public class WishListAuthorConfiguration : IEntityTypeConfiguration<WishListAuthor>
{
    public void Configure(EntityTypeBuilder<WishListAuthor> builder)
    {
        builder.HasKey(wla => new { wla.WishListId, wla.AuthorId });

        builder.HasOne(wla => wla.WishList)
            .WithMany(w => w.WishListAuthors)
            .HasForeignKey(wla => wla.WishListId)
            .IsRequired();

        builder.HasOne(wla => wla.Author)
            .WithMany(a => a.WishListAuthors)
            .HasForeignKey(wla => wla.AuthorId)
            .IsRequired();
    }
}