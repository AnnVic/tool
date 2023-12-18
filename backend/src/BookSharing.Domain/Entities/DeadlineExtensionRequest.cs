using BookSharing.Domain.Enums;

namespace BookSharing.Domain.Entities;

public class DeadlineExtensionRequest
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public DateTime StartDate { get; set; }
    public DeadlineExtensionStatus Status { get; set; }
}