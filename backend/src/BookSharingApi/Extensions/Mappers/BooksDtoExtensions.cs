using BookSharing.Domain.Entities;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class BookDtoExtensions
{
    public static IEnumerable<BookShortDto> ToShortDto(this IEnumerable<Book> books)
    {
        return books.Select(book => new BookShortDto
        {
            Id = book.Id,
            Title = book.Title,
            CoverImage = book.CoverImage
        }).ToList();
    }
}