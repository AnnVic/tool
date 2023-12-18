using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Queries;

public record GetBooksQuery() : IRequest<IEnumerable<Book>>
{
    public string SearchQuery { get; init; }
    public List<string> GenreNames { get; init; }
    public BookAvailabilityStatus? AvailabilityStatus { get; init; }
    public LanguageEnum? Language { get; init; }
}