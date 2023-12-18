using BookSharing.Domain.Entities;

namespace BookSharing.Contracts.Interfaces.Repositories;

public interface IProfileRepository
{
    Task<User> GetUserProfileByIdAsync(string UserId);
    Task SaveChangesAsync();
    Task Update(User userProfile);
}