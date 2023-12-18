using Microsoft.AspNetCore.Http;

namespace BookSharing.Infrastructure.Services;

public class BookImageStorageService : IBookImageStorageService
{
    public const string IMAGEFOLDER = "StaticFiles/";

    public async Task<string> SaveFileAsync(IFormFile file, string fileName)
    {
        var filePath = Path.Combine(IMAGEFOLDER, fileName);
        
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return filePath;
    }
}
