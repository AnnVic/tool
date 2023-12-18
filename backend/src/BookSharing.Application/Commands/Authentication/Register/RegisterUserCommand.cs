using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookSharing.Application.Commands;

public record RegisterUserCommand
    (string Email, string Password, string FirstName, string LastName, string UserName) : IRequest<IdentityResult>;