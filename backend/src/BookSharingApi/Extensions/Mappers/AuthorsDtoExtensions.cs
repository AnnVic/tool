using BookSharing.Domain.Entities;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class AuthorsDtoExtensions
{
    public static IEnumerable<AuthorDto> ToDto(this IEnumerable<Author> authors)
    {
        List<AuthorDto> authorsDto = new List<AuthorDto>();
        
        foreach (var author in authors)
        {
            authorsDto.Add(new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                Status = author.Status
            });
        }

        return authorsDto;
    }
}