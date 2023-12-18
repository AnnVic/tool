using BookSharing.Domain.Entities;
using BookSharingApi.DTO;

namespace BookSharingApi.Extensions.Mappers;

public static class GenresDtoExtensions
{
    public static IEnumerable<GenreDto> ToDto(this IEnumerable<Genre> genres)
    {
        var genresDto = new List<GenreDto>();

        foreach (var genre in genres)
        {
            genresDto.Add(new GenreDto()
            {
                Id = genre.Id,
                Name = genre.Name
            });
        }

        return genresDto;
    }
}