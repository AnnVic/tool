using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Commands.Genres;

public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, Unit>
{
    private readonly IBaseRepository<Genre> _repository;

    public AddGenreCommandHandler(IBaseRepository<Genre> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre
        {
            Name = request.Name
        };
        await _repository.CreateAsync(genre);
        await _repository.SaveAsync();
        return Unit.Value;
    }
}

