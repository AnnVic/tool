using BookSharing.Application.Commands;
using BookSharing.Application.Queries;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharingApi.DTO;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserInfo _userInfoService;
    private readonly IProfileRepository _profileRepository;
    private readonly IValidatorFactory _validatorFactory;

    public ProfileController(IMediator mediator, IUserInfo userInfo, IProfileRepository profileRepository,
        IValidatorFactory validatorFactory)
    {
        _mediator = mediator;
        _userInfoService = userInfo;
        _profileRepository = profileRepository;
        _validatorFactory = validatorFactory;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserProfileDto>> GetUserProfileInfo()
    {
        var userProfile = await _mediator.Send(new GetUserProfileInfoQuery { UserId = _userInfoService.GetUserId() });

        var returnedUserProfileInfo = new UserProfileDto()
        {
            Email = userProfile.Email,
            UserName = userProfile.UserName,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName
        };

        return Ok(returnedUserProfileInfo);
    }

    [Authorize]
    [HttpPatch]
    public async Task<IActionResult> UpdateUserProfileInfo([FromBody] UserProfileDto updatedProfile)
    {
        var validator = _validatorFactory.GetValidator<UserProfileDto>();
        var validationResult = await validator.ValidateAsync(updatedProfile);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var userId = _userInfoService.GetUserId();
        if (userId == null)
        {
            return BadRequest("Couldn't obtain id");
        }

        var user = await _profileRepository.GetUserProfileByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"User wasn't found");
        }

        user.FirstName = updatedProfile.FirstName ?? user.FirstName;
        user.LastName = updatedProfile.LastName ?? user.LastName;
        user.UserName = updatedProfile.UserName ?? user.UserName;
        user.Email = updatedProfile.Email ?? user.Email;

        await _mediator.Send(new UpdateUserProfileInfoCommand(userId, user));

        return Ok();
    }
}