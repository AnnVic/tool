using BookSharing.Application.Commands;
using BookSharing.Application.Commands.BookManagement;
using BookSharing.Application.Queries;
using BookSharing.Application.Queries.BookManagement;
using BookSharing.Application.Queries.Books.UserBooks;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Enums;
using BookSharingApi.DTO;
using BookSharingApi.Extensions.Mappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPaginationService _paginationService;

    public BooksController(IMediator mediator, IPaginationService paginationService)
    {
        _mediator = mediator;
        _paginationService = paginationService;

    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto updateBookDto)
    {
        var command = new UpdateBookCommand(
            updateBookDto.Id,
            updateBookDto.Title,
            updateBookDto.Authors,
            updateBookDto.Genres,
            updateBookDto.Language,
            updateBookDto.Date
        );

        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _mediator.Send(new DeleteBookCommand { Id = id });

        return Ok();

    }

    [HttpGet]
    public async Task<ActionResult<object>> GetBooks(
        [FromQuery] int page = 1,
        [FromQuery] string search = null,
        [FromQuery] List<string> genreNames = null,
        [FromQuery] BookAvailabilityStatus? availabilityStatus = null,
        [FromQuery] LanguageEnum? language = null)
    {
        var query = new GetBooksQuery
        {
            SearchQuery = search,
            GenreNames = genreNames,
            AvailabilityStatus = availabilityStatus,
            Language = language
        };

        var books = await _mediator.Send(query);
        var booksShortDto = books.ToShortDto();

        var paginatedResult = _paginationService.Paginate(booksShortDto, page);

        return new
        {
            paginatedResult.Items,
            paginatedResult.Page,
            paginatedResult.TotalPages,
            paginatedResult.TotalItems
        };
    }

    [HttpGet("user-books")]
    public async Task<ActionResult<object>> GetUserBooks([FromQuery] int page = 1)
    {
        var result = await _mediator.Send(new GetUserBooksQuery());


        var paginatedResult = _paginationService.Paginate(result.ToShortDto(), page);

        return new
        {
            paginatedResult.Items,
            paginatedResult.Page,
            paginatedResult.TotalPages,
            paginatedResult.TotalItems
        };
    }

    [HttpPost]
    public async Task<IActionResult> UploadBook([FromForm] UploadBookCommand request)
    {
        var bookId = await _mediator.Send(request);
        return Ok(bookId);
    }

    [HttpGet("BookDetails")]
    public async Task<IActionResult> GetBookDetails(int id)
    {
        var book = await _mediator.Send(new GetBookDetailsQuery { BookId = id });

        if (book is null)
        {
            return NotFound("Book with specified id not found");
        }

        var bookToReturn = new BookDetailsDto
        {
            Title = book.Title,
            ImageFile = book.ImageFile,
            UploaderUsername = book.UploaderUsername,
            Authors = book.Authors,
            Genres = book.Genres,
            Language = book.Language,
            PublicationDate = book.PublicationDate,
            AvailabilityStatus = book.AvailabilityStatus,
            IsAssignButtonActive = book.IsAssignButtonActive
        };
        return Ok(bookToReturn);
    }
}