using BookSharing.Contracts.Interfaces.Services;

namespace BookSharing.Application.Services;

public class PaginationService : IPaginationService
{
    private const int PageSize = 12;

    public PaginatedResult<TDto> Paginate<TDto>(IEnumerable<TDto> items, int page)
    {
        var totalItems = items.Count();

        var skip = (page - 1) * PageSize;

        // Get the items for the current page
        var paginatedItems = items.Skip(skip).Take(PageSize);

        // Calculate total pages
        var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

        return new PaginatedResult<TDto>
        {
            Items = paginatedItems,
            Page = page,
            TotalPages = totalPages,
            TotalItems = totalItems
        };
    }
}