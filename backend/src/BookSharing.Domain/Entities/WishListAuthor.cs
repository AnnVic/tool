namespace BookSharing.Domain.Entities;

public class WishListAuthor
{
    public int WishListId { get; set; }
    public WishList WishList { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
}