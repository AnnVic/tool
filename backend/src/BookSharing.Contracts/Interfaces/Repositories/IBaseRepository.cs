using BookSharing.Domain.Entities;
using System.Linq.Expressions;

namespace BookSharing.Contracts.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

    IQueryable<T> GetAll();

    Task CreateAsync(T entity);

    void UpdateAsync(T entity);

    void DeleteAsync(T entity);

    Task SaveAsync();
    void DeleteRange(IEnumerable<T> entities);
    void UpdateRange(IEnumerable<T> entities);
}