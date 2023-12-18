using BookSharing.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Contracts.Interfaces.DbContext;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<IdentityRole<Guid>> Roles { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<DeadlineExtensionRequest> DeadlineExtensionRequests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<WishListAuthor> WishListAuthors { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
