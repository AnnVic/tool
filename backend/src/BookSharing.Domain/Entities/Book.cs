using BookSharing.Domain.Enums;

namespace BookSharing.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }
    public string CoverImage { get; set; }
    public UploadBookStatus UploadStatus { get; set; }
    public BookAvailabilityStatus AvailabilityStatus { get; set; }
    public Guid UploaderId { get; set; }
    public User Uploader { get; set; }

    public Assignment Assignment { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
}