using BookSharing.Domain.Enums;

namespace BookSharingApi.DTO;

public class AssignmentDto
{
    public string Title { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public AssignmentStatus Status { get; set; }
}