using Microsoft.AspNetCore.Http;

namespace BookSharing.Infrastructure.Services;

public interface IBookImageStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string fileName);
}
