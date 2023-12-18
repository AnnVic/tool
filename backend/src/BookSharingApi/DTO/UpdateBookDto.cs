using BookSharing.Domain.Enums;

namespace BookSharingApi.Controllers;

public class UpdateBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<string> Authors { get; set; }
    public IEnumerable<string> Genres { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime Date { get; set; }
}

