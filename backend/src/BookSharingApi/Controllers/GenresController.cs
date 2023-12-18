using BookSharing.Application.Commands.Authors;
using BookSharing.Application.Commands.Genres;
using BookSharing.Application.Queries;
using BookSharingApi.DTO;
using BookSharingApi.Extensions.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Route("[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
    {
        var genres = await _mediator.Send(new GetGenresQuery());
        var genresDto = genres.ToDto();
        return Ok(genresDto);
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<GenreDto>>> AddGenres([FromBody] AddGenreCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}