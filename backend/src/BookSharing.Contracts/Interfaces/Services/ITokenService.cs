using BookSharing.Domain.Entities;

namespace BookSharing.Contracts.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
