using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;

namespace BookSharing.Contracts.Interfaces.Repositories;

public interface IBookRepository
{
    Task<int> CreateAsync(Book book);
    Task<Book> GetAsync(int id);
    Task<IEnumerable<Book>> GetFilteredBooksAsync(
        string searchGenre, List<string> genreNames, BookAvailabilityStatus? availabilityStatus, LanguageEnum? language);
}
