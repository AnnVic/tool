using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries;

public record GetUserProfileInfoQuery : IRequest<User>
{
    public string UserId { get; set; }
}