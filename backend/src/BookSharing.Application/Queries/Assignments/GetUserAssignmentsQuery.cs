using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries.Assignments;

public record GetUserAssignmentsQuery : IRequest<IEnumerable<Assignment>>
{
}