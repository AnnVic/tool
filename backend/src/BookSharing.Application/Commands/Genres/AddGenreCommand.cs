using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Commands.Genres;

public record AddGenreCommand : IRequest<Unit>
{
    public string Name { get; set; }
}
