using BookSharing.Infrastructure.Services;
using BookSharingApi.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddAuthenticationService(builder.Configuration);
    builder.Services.AddAuthorization();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddValidationServices();
    builder.Services.AddMediatrService();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddCustomServices();
    builder.Services.AddSwaggerServices();
    builder.Services.AddLogging();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
    app.ConfigureCustomExceptionMiddleware();
    app.UseHttpsRedirection();

    DirectoryHelper.EnsureDirectoryExists(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles"));

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
        RequestPath = "/StaticFiles"
    });

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}