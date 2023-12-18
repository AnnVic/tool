using BookSharing.Contracts.Interfaces.DbContext;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly IAppDbContext _appDbContext;
    public ProfileRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> GetUserProfileByIdAsync(string userId)
    {
        var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Id.ToString() == userId);
        if (user is null)
        {
            //implement
        }
        return user;
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(User userProfile)
    {
        _appDbContext.Users.Update(userProfile);
        await SaveChangesAsync();
    }
}