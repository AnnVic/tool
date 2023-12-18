using BookSharing.Application.Models;
using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Commands.BookManagement;

public record UpdateBookCommand : IRequest<Unit>
{
    public UpdateBookCommand(int id, string title, IEnumerable<string> authors, IEnumerable<string> genres, LanguageEnum language, DateTime publicationDate)
    {
        Id = id;
        Title = title;
        Authors = authors;
        Genres = genres;
        Language = language;
        PublicationDate = publicationDate;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<string> Authors { get; set; }
    public IEnumerable<string> Genres { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }
}
