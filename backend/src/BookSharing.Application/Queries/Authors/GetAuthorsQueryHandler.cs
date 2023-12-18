using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Application.Queries.Authors;

public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<Author>>
{
    private readonly IBaseRepository<Author> _authorRepository;

    public GetAuthorsQueryHandler(IBaseRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        return await _authorRepository.GetAll().ToListAsync(cancellationToken);
    }
}