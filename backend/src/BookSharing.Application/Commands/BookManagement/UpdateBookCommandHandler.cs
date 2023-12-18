using BookSharing.Application.Services;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Commands.BookManagement;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly BookService _bookService;
    private readonly IBaseRepository<Domain.Entities.Author> _authorRepository;
    private readonly IBaseRepository<Genre> _genreRepository;

    public UpdateBookCommandHandler(BookService bookService, IBaseRepository<Domain.Entities.Author> authorRepository, IBaseRepository<Genre> genreRepository)
    {
        _bookService = bookService;
        _authorRepository = authorRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var authors = request.Authors;
        var genres=request.Genres;

        var book = new Book
        {
            Title = request.Title,
            Language = request.Language,
            PublicationDate = request.PublicationDate,
        };

        await _bookService.UpdateBook(request.Id, book, authors, genres);

        return Unit.Value;
    }
}
