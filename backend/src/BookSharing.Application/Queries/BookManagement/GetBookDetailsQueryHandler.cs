using BookSharing.Application.Models;
using BookSharing.Application.Services;
using MediatR;

namespace BookSharing.Application.Queries.BookManagement;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailed>
{
    private readonly BookService _bookService;

    public GetBookDetailsQueryHandler(BookService bookService)
    {
        _bookService = bookService;
    }

    public Task<BookDetailed> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        var book= _bookService.GetBookDetails(request.BookId);
        return book;    
    }
}
