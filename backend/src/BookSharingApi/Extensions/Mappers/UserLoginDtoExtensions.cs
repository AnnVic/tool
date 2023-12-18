using BookSharing.Application.Commands;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class UserLoginDtoExtensions
{
    public static LoginUserCommand ToCommand(this UserLoginDto userDto)
    {
        return new LoginUserCommand
        {
            UserName = userDto.UserName,
            Password = userDto.Password
        };
    }
}