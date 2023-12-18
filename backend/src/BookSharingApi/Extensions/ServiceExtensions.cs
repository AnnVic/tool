using BookSharing.Application.Services;
using BookSharing.Contracts.Interfaces.DbContext;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Infrastructure.Persistence;
using BookSharing.Infrastructure.Persistence.Repositories;
using BookSharing.Infrastructure.Services;

namespace BookSharingApi.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserInfo, UserInfo>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IAppDbContext, AppDbContext>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookImageStorageService,  BookImageStorageService>();
        services.AddScoped<IPaginationService, PaginationService>();
        services.AddScoped<BookService>();
    }
}
