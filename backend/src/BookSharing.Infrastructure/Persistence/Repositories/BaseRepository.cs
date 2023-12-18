using System.Linq.Expressions;
using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    private AppDbContext AppDbContext { get; set; }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return AppDbContext.Set<T>().Where(expression).AsNoTracking();
    }

    public IQueryable<T> GetAll()
    {
        return AppDbContext.Set<T>().AsNoTracking();
    }

    public async Task CreateAsync(T entity)
    {
        await AppDbContext.Set<T>().AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        AppDbContext.Set<T>().Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        AppDbContext.Set<T>().Remove(entity);
    }

    public async Task SaveAsync()
    {
        await AppDbContext.SaveChangesAsync();
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        AppDbContext.RemoveRange(entities);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        AppDbContext.Set<T>().UpdateRange(entities);
    }
}