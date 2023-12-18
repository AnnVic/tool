using BookSharing.Application.Extensions;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Constants;
using BookSharing.Domain.CustomExceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookSharing.Application.Commands.Authentication.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
{
    private readonly IUserService _userService;

    public RegisterUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        var result = await _userService.CreateUserAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userService.AddUserToRoleAsync(user.Id.ToString(), Roles.User);
            return result;
        }
        foreach (var error in result.Errors)
        {
            if (error.Code == "DuplicateUserName" || error.Code == "DuplicateEmail")
            {
                throw new BaseException("User with the same email or username already exists", ErrorCode.RegistrationUsernameEmailTaken);
            }

        }
        return result;
    }
}