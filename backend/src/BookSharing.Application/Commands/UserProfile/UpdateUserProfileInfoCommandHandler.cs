using BookSharing.Contracts.Interfaces.Repositories;
using MediatR;

namespace BookSharing.Application.Commands.UserProfile;

public class UpdateUserProfileInfoCommandHandler : IRequestHandler<UpdateUserProfileInfoCommand, Unit>
{
    private readonly IProfileRepository _repository;

    public UpdateUserProfileInfoCommandHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateUserProfileInfoCommand request, CancellationToken cancellationToken)
    {
        var userProfile = await _repository.GetUserProfileByIdAsync(request.UserId);

        userProfile.FirstName = request.User.FirstName ?? userProfile.FirstName;
        userProfile.LastName = request.User.LastName ?? userProfile.LastName;
        userProfile.UserName = request.User.UserName ?? userProfile.UserName;
        userProfile.Email = request.User.Email ?? userProfile.Email;
        userProfile.NormalizedUserName = request.User.UserName.ToUpperInvariant() ?? userProfile.UserName;
        await _repository.Update(userProfile);

        return Unit.Value;
    }
}