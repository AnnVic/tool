using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries;

public record GetAuthorsQuery() : IRequest<IEnumerable<Author>>
{
}