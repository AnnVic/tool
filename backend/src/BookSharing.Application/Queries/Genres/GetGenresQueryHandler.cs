using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Application.Queries.Genres;

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<Genre>>
{
    private readonly IBaseRepository<Genre> _genreRepository;

    public GetGenresQueryHandler(IBaseRepository<Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetAll().ToListAsync(cancellationToken);
    }
}