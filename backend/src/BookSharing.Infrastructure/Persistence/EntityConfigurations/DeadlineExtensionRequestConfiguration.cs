using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.EntityConfigurations;

public class DeadlineExtensionRequestConfiguration : IEntityTypeConfiguration<DeadlineExtensionRequest>
{
    public void Configure(EntityTypeBuilder<DeadlineExtensionRequest> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.StartDate)
            .IsRequired();

        builder.HasOne(d => d.Assignment)
            .WithMany(a => a.DeadlineExtensionRequests)
            .HasForeignKey(d => d.AssignmentId)
            .IsRequired();
    }
}