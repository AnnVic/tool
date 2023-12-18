using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries.Books;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetFilteredBooksAsync(
            request.SearchQuery, request.GenreNames, request.AvailabilityStatus, request.Language);
    }
}