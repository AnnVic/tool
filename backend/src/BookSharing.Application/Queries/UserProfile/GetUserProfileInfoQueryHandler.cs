using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.CustomExceptions;
using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries.UserProfile;

public class GetUserProfileInfoQueryHandler : IRequestHandler<GetUserProfileInfoQuery, User>
{
    private readonly IProfileRepository _profileRepository;
    public GetUserProfileInfoQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<User> Handle(GetUserProfileInfoQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _profileRepository.GetUserProfileByIdAsync(request.UserId);
        if (userProfile is null)
        {
            throw new BaseException("Profile not found", ErrorCode.ProfileNotFound);
        }
        return userProfile;
    }
}
