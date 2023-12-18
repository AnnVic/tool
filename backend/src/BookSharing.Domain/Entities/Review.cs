namespace BookSharing.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Rating { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}