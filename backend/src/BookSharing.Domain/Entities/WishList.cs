namespace BookSharing.Domain.Entities;

public class WishList
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string CustomAuthor { get; set; }

    public ICollection<WishListAuthor> WishListAuthors { get; set; }
}