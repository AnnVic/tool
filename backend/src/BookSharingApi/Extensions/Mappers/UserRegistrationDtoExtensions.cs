using BookSharing.Application.Commands;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class UserRegistrationDtoExtensions
{
    public static RegisterUserCommand ToCommand(this UserRegistrationDto dto)
    {
        return new RegisterUserCommand(
            FirstName: dto.FirstName,
            LastName: dto.LastName,
            UserName: dto.UserName,
            Email: dto.Email,
            Password: dto.Password
        );
    }
}