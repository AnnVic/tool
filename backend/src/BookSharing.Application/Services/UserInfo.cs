using BookSharing.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BookSharing.Application.Services;

public class UserInfo : IUserInfo
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserInfo(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUserId()
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

        return userIdClaim?.Value;
    }
}
