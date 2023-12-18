namespace BookSharing.Contracts.Interfaces.Services;

public interface IPaginationService
{
    PaginatedResult<TDto> Paginate<TDto>(IEnumerable<TDto> items, int page);
}

public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}