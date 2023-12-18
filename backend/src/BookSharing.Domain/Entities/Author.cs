using BookSharing.Domain.Enums;

namespace BookSharing.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AuthorStatus Status { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<WishListAuthor> WishListAuthors { get; set; }
}