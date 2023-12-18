using BookSharing.Application.Queries.Assignments;
using BookSharing.Application.Commands;
using BookSharingApi.DTO;
using BookSharingApi.Extensions.Mappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentController(IMediator mediator)
    {
        _mediator = mediator;   
    }

    [HttpGet("user-assignments")]
    public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
    {
        var result = await _mediator.Send(new GetUserAssignmentsQuery());

        return Ok(result.ToDto());
    }

    [HttpPost("assign-to-me")]
    public async Task<ActionResult<string>> AssignToMe([FromBody] AddAssignmentCommand request)
    {
        await _mediator.Send(request);
        return Ok("Book was successfully assigned");
    }
}