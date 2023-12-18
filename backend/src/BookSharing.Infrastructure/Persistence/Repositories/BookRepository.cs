using BookSharing.Contracts.Interfaces.DbContext;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IAppDbContext _appDbContext;

    public BookRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateAsync(Book book)
    {
        _appDbContext.Books.Add(book);
        await _appDbContext.SaveChangesAsync();
        return book.Id;
    }

    public async Task<Book> GetAsync(int id)
    {
        return await _appDbContext.Books.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetFilteredBooksAsync(
        string searchQuery, 
        List<string> genreNames, 
        BookAvailabilityStatus? availabilityStatus, 
        LanguageEnum? language)
    {
        var query = _appDbContext.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(b =>
                EF.Functions.Like(b.Title, $"%{searchQuery}%") ||
                b.BookAuthors.Any(ba => EF.Functions.Like(ba.Author.Name, $"%{searchQuery}%"))
            );
        }

        if (genreNames?.Any() == true)
        {
            query = query.Where(b => b.BookGenres.Any(bg => genreNames.Contains(bg.Genre.Name)));
        }

        if (availabilityStatus.HasValue)
        {
            query = query.Where(b => b.AvailabilityStatus == availabilityStatus);
        }

        if (language.HasValue)
        {
            query = query.Where(b => b.Language == language);
        }

        // TODO: add rating filtering
        //if (minRating.HasValue)
        //{
        //    query = query.Where(b => b.Reviews.Any() && b.Reviews.Average(r => r.Rating) >= minRating.Value);
        //}

        query = query.OrderBy(b => b.Title);

        return await query.ToListAsync();
    }
}