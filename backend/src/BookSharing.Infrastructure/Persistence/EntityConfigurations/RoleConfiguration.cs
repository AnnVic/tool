using BookSharing.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSharing.Infrastructure.Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = Roles.User, NormalizedName = Roles.User.ToUpper() },
            new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = Roles.Admin, NormalizedName = Roles.Admin.ToUpper() },
            new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = Roles.SuperAdmin, NormalizedName = Roles.SuperAdmin.ToUpper() });
    }
}