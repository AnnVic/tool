using BookSharing.Application.Models;
using BookSharing.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using BookSharing.Application.Queries.Assignments;
using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Services;

public class BookService
{
    private readonly IBaseRepository<BookAuthor> _bookAuthorRepository;
    private readonly IBaseRepository<BookGenre> _bookGenreRepository;
    private readonly IBaseRepository<Book> _bookRepository;
    private readonly IBaseRepository<Author> _authorRepository;
    private readonly IBaseRepository<Genre> _genreRepository;
    private readonly IMediator _mediator;

    public BookService(
        IBaseRepository<BookAuthor> bookAuthorRepository,
        IBaseRepository<BookGenre> bookGenreRepository,
        IBaseRepository<Book> bookRepository,
        IBaseRepository<Author> authorRepo,
        IBaseRepository<Genre> genreRepo,
        IMediator mediator)
    {
        _bookAuthorRepository = bookAuthorRepository;
        _bookGenreRepository = bookGenreRepository;
        _bookRepository = bookRepository;
        _authorRepository = authorRepo;
        _genreRepository = genreRepo;
        _mediator = mediator;
    }

    public async Task<BookDetailed> GetBookDetails(int id)
    {
        var bookDetails = await _bookRepository.FindByCondition(b => b.Id == id)
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(b => b.Uploader)
            .Select(book => new BookDetailed
            {
                Title = book.Title,
                Authors = book.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                Genres = book.BookGenres.Select(bg => bg.Genre.Name).ToList(),
                UploaderUsername = book.Uploader.UserName,
                AvailabilityStatus = book.AvailabilityStatus,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ImageFile = book.CoverImage
            })
            .FirstOrDefaultAsync();

        var userAssignments = await _mediator.Send(new GetUserAssignmentsQuery());

        bookDetails.IsAssignButtonActive = GetAssignButtonState(bookDetails.AvailabilityStatus, userAssignments);

        return bookDetails;
    }

    private bool GetAssignButtonState(BookAvailabilityStatus availabilityStatus, IEnumerable<Assignment> userAssignments)
    {
        var activeAssignmentsCount = userAssignments.Count(a => a.Status == AssignmentStatus.Active);

        var pendingAssignmentsCount = userAssignments.Count(a => a.Status == AssignmentStatus.Pending);
        
        if (pendingAssignmentsCount == 1)
        {
            return false;
        }

        return availabilityStatus == BookAvailabilityStatus.Free 
               && activeAssignmentsCount <= 2 
               && pendingAssignmentsCount < 1;
    }

    public async Task UpdateBook(int id, Book updatedBook, IEnumerable<string> authors, IEnumerable<string> genres)
    {
        var existingBook = await _bookRepository.FindByCondition(b => b.Id == id)
                                             .Include(b => b.BookAuthors)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();

        if (existingBook.Title != updatedBook.Title)
        {
            existingBook.Title = updatedBook.Title;
        }

        if (existingBook.Language != updatedBook.Language)
        {
            existingBook.Language = updatedBook.Language;
        }

        if (existingBook.PublicationDate != updatedBook.PublicationDate)
        {
            existingBook.PublicationDate = updatedBook.PublicationDate;
        }

        var updatedAuthorsNames = authors;
        var updatedGenresNames = genres;

        var exAuth = existingBook.BookAuthors;
        var exGenr = existingBook.BookGenres;
        if (exGenr != null)
        {
            _bookGenreRepository.DeleteRange(exGenr);
            exGenr.Clear();
        }


        exGenr = exGenr ?? new List<BookGenre>();

        foreach (var genreName in updatedGenresNames)
        {
            var genreId = _genreRepository.FindByCondition(a => a.Name == genreName)
                                            .Select(a => a.Id)
                                            .FirstOrDefault();

            var existingBookGenre = exGenr.FirstOrDefault(bg => bg.GenreId == genreId);

            if (existingBookGenre == null)
            {
                exGenr.Add(new BookGenre { BookId = id, GenreId = genreId });
            }
        }

        if (exAuth != null)
        {
            _bookAuthorRepository.DeleteRange(exAuth);
            exAuth.Clear();
        }


        exAuth = exAuth ?? new List<BookAuthor>();

        foreach (var authorName in updatedAuthorsNames)
        {
            var authorId = _authorRepository.FindByCondition(a => a.Name == authorName)
                                            .Select(a => a.Id)
                                            .FirstOrDefault();
            if (authorId != default)
            {
                var existingBookAuthor = existingBook.BookAuthors.FirstOrDefault(ba => ba.AuthorId == authorId);

                if (existingBookAuthor == null)
                {
                    exAuth.Add(new BookAuthor { BookId = id, AuthorId = authorId });
                }
            }
            else
            {
                var newAuthor = new Author { Name = authorName };
                await _authorRepository.CreateAsync(newAuthor);
                await _authorRepository.SaveAsync();

                exAuth.Add(new BookAuthor { BookId = id, AuthorId = newAuthor.Id });
            }
        }

        await _bookAuthorRepository.SaveAsync();
        _bookAuthorRepository.UpdateRange(exAuth);
        await _bookAuthorRepository.SaveAsync();
        _bookGenreRepository.UpdateRange(exGenr);
        await _bookGenreRepository.SaveAsync();
        _bookRepository.UpdateAsync(existingBook);
        await _bookRepository.SaveAsync();
        await _bookAuthorRepository.SaveAsync();
    }
}