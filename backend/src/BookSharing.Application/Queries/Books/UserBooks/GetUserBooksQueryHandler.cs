using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Application.Queries.Books.UserBooks;

public class GetUserBooksQueryHandler : IRequestHandler<GetUserBooksQuery, IEnumerable<Book>>
{
    private readonly IUserInfo _userInfoService;
    private readonly IBaseRepository<Book> _bookRepository;

    public GetUserBooksQueryHandler(IUserInfo userInfoService, IBaseRepository<Book> bookRepository)
    {
        _userInfoService = userInfoService;
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(GetUserBooksQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _userInfoService.GetUserId();

        if (!Guid.TryParse(currentUserId, out Guid guidUserId))
        {
            return Enumerable.Empty<Book>();
        }

        var userBooks = await _bookRepository
            .FindByCondition(b => b.UploaderId == guidUserId)
            .ToListAsync(cancellationToken);

        return userBooks;
    }
}