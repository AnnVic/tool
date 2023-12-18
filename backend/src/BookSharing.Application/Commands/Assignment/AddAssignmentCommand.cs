using MediatR;

namespace BookSharing.Application.Commands;

public record AddAssignmentCommand : IRequest<Unit>
{
    public int BookId { get; set; }
}