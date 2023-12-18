using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.CustomExceptions;
using BookSharing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookSharing.Application.Commands.Authentication.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
        if (!result.Succeeded)
        {
            throw new BaseException("Invalid username or password provided. Please double-check and try again.", ErrorCode.LoginInvalidCredentials);
        }

        var token = _tokenService.GenerateToken(await _userManager.FindByNameAsync(request.UserName));

        return token;
    }
}
