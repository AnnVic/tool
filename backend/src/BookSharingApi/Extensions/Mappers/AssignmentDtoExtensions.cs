using BookSharing.Domain.Entities;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class AssignmentDtoExtensions
{
    public static IEnumerable<AssignmentDto> ToDto(this IEnumerable<Assignment> assignments)
    {
        return assignments.Select(assignment => new AssignmentDto()
        {
            Title = assignment.Book.Title, StartDate = assignment.StartDate, EndDate = assignment.EndDate,
            Status = assignment.Status
        });
    }
}