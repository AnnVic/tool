using BookSharing.Application.Commands;

namespace BookSharingApi.Extensions;

public static class MediatrExtension
{
    public static void AddMediatrService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly); });
    }
}
