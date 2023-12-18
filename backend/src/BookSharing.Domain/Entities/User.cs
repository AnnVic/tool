using Microsoft.AspNetCore.Identity;

namespace BookSharing.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Review> Reviews { get; set; }
    public ICollection<Book> UploadedBooks { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
}