using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Commands.Authors;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Unit>
{
    private readonly IBaseRepository<Domain.Entities.Author> _repository;

    public AddAuthorCommandHandler(IBaseRepository<Domain.Entities.Author> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Domain.Entities.Author
        {
            Name = request.Name,
            Status = request.Status
        };
        await _repository.CreateAsync(author);
        await _repository.SaveAsync();
        return Unit.Value;
    }
}
