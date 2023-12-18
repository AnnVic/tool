using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Commands;

public record UpdateUserProfileInfoCommand : IRequest<Unit>
{
    public UpdateUserProfileInfoCommand(string userId, User user)
    {
        UserId = userId;
        User = user;
    }

    public string UserId { get; set; }
    public User User {  get; set; }
}
