using BookSharing.Domain.Enums;

namespace BookSharing.Domain.Entities;

public class Assignment
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public AssignmentStatus Status { get; set; }

    public ICollection<DeadlineExtensionRequest> DeadlineExtensionRequests { get; set; }
}