using BookSharing.Application.Commands;
using BookSharing.Domain.Entities;

namespace BookSharing.Application.Extensions;

public static class CommandToEntityMappings
{
    public static User ToEntity(this RegisterUserCommand command)
    {
        return new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.UserName,
            Email = command.Email,
            PasswordHash = command.Password
        };
    }
}