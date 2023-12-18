using BookSharing.Domain.Entities;
using MediatR;

namespace BookSharing.Application.Queries.Books.UserBooks;

public record GetUserBooksQuery() : IRequest<IEnumerable<Book>>
{
}