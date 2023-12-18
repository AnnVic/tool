using BookSharing.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookSharing.Contracts.Interfaces.Services;

public interface IUserService
{
    Task AddUserToRoleAsync(string userId, string roleName);
    Task<IdentityResult> CreateUserAsync(User user, string password);
}