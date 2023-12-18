using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;

namespace BookSharingApi.DTO;

public class BookDetailsDto
{
    public string Title { get; set; }
    public IEnumerable<string> Genres { get; set; }
    public IEnumerable<string> Authors { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ImageFile { get; set; }
    public BookAvailabilityStatus AvailabilityStatus { get; set; }
    public string UploaderUsername { get; set; }
    public bool IsAssignButtonActive { get; set; }
}
