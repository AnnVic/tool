using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Commands.Authors;

public record AddAuthorCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public AuthorStatus Status { get; set; }
}
