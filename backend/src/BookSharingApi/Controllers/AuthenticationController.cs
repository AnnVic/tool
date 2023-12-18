using BookSharingApi.DTO;
using BookSharingApi.Extensions.Mappers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookSharing.Contracts.Interfaces.Services;

namespace BookSharingApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidatorFactory _validatorFactory;
    private readonly IUserInfo _userInfoService;
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(IMediator mediator, IValidatorFactory validatorFactory, IUserInfo userInfoService,
        ILogger<AuthenticationController> logger)
    {
        _mediator = mediator;
        _validatorFactory = validatorFactory;
        _userInfoService = userInfoService;
        _logger = logger;
    }

    [HttpPost("register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto registrationDto)
    {
        var validator = _validatorFactory.GetValidator<UserRegistrationDto>();
        var validationResult = await validator.ValidateAsync(registrationDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var command = registrationDto.ToCommand();

        var result = await _mediator.Send(command);
        if (result.Succeeded)
        {
            return Ok(new { Code = StatusCodes.Status200OK, Message = "New account has been successfully created." });
        }

        return BadRequest(result.Errors);
    }


    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        var validator = _validatorFactory.GetValidator<UserLoginDto>();
        var validationResult = await validator.ValidateAsync(loginDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var loginCommand = loginDto.ToCommand();

        var token = await _mediator.Send(loginCommand);

        return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("getId")]
    public IActionResult GetId()
    {
        var userId = _userInfoService.GetUserId();

        return Ok($"User Id is: {userId}");
    }
}