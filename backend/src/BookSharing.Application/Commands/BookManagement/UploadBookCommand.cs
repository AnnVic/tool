using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookSharing.Application.Commands;

public record UploadBookCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }
    public IFormFile BookImage { get; set; }
    public IEnumerable<string> AuthorNames { get; set; }
    public IEnumerable<string> GenreNames { get; set; }
}
