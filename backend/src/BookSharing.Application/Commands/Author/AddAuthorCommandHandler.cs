using BookSharing.Contracts.Interfaces.Repositories;
using MediatR;

namespace BookSharing.Application.Commands.Author;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Unit>
{
    private readonly IBaseRepository<Domain.Entities.Author> _repo;

    public AddAuthorCommandHandler(IBaseRepository<Domain.Entities.Author> repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Domain.Entities.Author
        {
            Name = request.Name,
            Status = 0
        };
        await _repo.CreateAsync(author);
        await _repo.SaveAsync();
        return Unit.Value;
    }
}
