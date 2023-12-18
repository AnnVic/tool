using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using BookSharing.Infrastructure.Services;
using MediatR;

namespace BookSharing.Application.Commands.BookManagement;

public class UploadBookCommandHandler : IRequestHandler<UploadBookCommand, Unit>
{
    private readonly IBookImageStorageService _bookImageStorageService;
    private readonly IUserInfo _userInfoService;
    private readonly IBaseRepository<Genre> _genreRepository;
    private readonly IBaseRepository<Domain.Entities.Author> _authorRepository;
    private readonly IBaseRepository<Book> _bookRepository;

    public UploadBookCommandHandler(
        IBookImageStorageService bookImageStorageService,
        IUserInfo userInfoService,
        IBaseRepository<Genre> genreRepository,
        IBaseRepository<Domain.Entities.Author> authorRepository,
        IBaseRepository<Book> bookRepository)
    {
        _bookImageStorageService = bookImageStorageService;
        _userInfoService = userInfoService;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(UploadBookCommand request, CancellationToken cancellationToken)
    {
        var fileName = $"{Guid.NewGuid()}_{request.Title}{Path.GetExtension(request.BookImage.FileName)}";
        await _bookImageStorageService.SaveFileAsync(request.BookImage, fileName);

        var uploaderIdString = _userInfoService.GetUserId();

        Guid.TryParse(uploaderIdString, out var uploaderIdGuid);

        var book = new Book
        {
            Title = request.Title,
            UploaderId = uploaderIdGuid,
            Language = request.Language,
            PublicationDate = request.PublicationDate,
            UploadStatus = 0,
            CoverImage = fileName,
            BookAuthors = new List<BookAuthor>(),
            BookGenres = new List<BookGenre>(),
        };

        foreach (var authorName in request.AuthorNames)
        {
            var author = _authorRepository.FindByCondition(a => a.Name == authorName).FirstOrDefault();

            if (author is null)
            {
                var addNewAuthor = new Domain.Entities.Author()
                {
                    Name = authorName,
                    Status = AuthorStatus.Unapproved
                };
                await _authorRepository.CreateAsync(addNewAuthor);

                await _authorRepository.SaveAsync();
                book.BookAuthors.Add(new BookAuthor { BookId = book.Id, AuthorId = addNewAuthor.Id });
            }
            else
            {
                book.BookAuthors.Add(new BookAuthor { BookId = book.Id, AuthorId = author.Id });
            }
        }

        foreach (var genreName in request.GenreNames)
        {
            var genre = _genreRepository.FindByCondition(a => a.Name == genreName).FirstOrDefault();
            book.BookGenres.Add(new BookGenre { BookId = book.Id, GenreId = genre.Id });
        }

        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveAsync();
        return Unit.Value;
    }
}