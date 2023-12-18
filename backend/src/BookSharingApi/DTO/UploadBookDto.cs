using BookSharing.Domain.Enums;

namespace BookSharingApi.DTO;

public class UploadBookDto
{
    public string Title { get; set; }

    public LanguageEnum Language { get; set; }

    public DateTime PublicationDate { get; set; }

    IFormFile BookImage { get; set; }

    public UploadBookStatus Status { get; set; } = 0;
}