using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries;

public record GetGenresQuery: IRequest<IEnumerable<Genre>>
{
}