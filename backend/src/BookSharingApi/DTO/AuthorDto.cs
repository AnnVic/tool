using BookSharing.Domain.Enums;

namespace BookSharingApi.DTO;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AuthorStatus Status { get; set; }
}