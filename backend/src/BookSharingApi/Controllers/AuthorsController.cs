using BookSharing.Application.Commands.Author;
using BookSharing.Application.Queries;
using BookSharingApi.DTO;
using BookSharingApi.Extensions.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewAuthor([FromForm] AddAuthorCommand request)
    {
        var authorId = await _mediator.Send(request);
        return Ok(authorId);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        var authors = await _mediator.Send(new GetAuthorsQuery());
        var authorsDto = authors.ToDto();
        return Ok(authorsDto);
    }
    [HttpPost("Add multiple authors")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> AddAuthors([FromBody] AddAuthorCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}