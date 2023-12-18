using BookSharing.Domain.Enums;

namespace BookSharing.Application.Models;

public class BookDetailed
{
    public string Title { get; set; }
    public IEnumerable<string> Genres { get; set; }
    public IEnumerable<string> Authors { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ImageFile { get; set; }
    public BookAvailabilityStatus AvailabilityStatus { get; set; }
    public string UploaderUsername { get; set; }
    public bool IsAssignButtonActive { get; internal set; }
}
