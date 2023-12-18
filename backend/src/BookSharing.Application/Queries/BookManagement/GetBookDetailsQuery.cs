using BookSharing.Application.Models;
using MediatR;

namespace BookSharing.Application.Queries.BookManagement;

public record GetBookDetailsQuery : IRequest<BookDetailed>
{
    public int BookId { get; set; }
}
