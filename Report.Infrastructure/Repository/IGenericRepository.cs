using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Report.Infrastructure.Repositories;

public interface IGenericRepository<TEntity, TKey>
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    IQueryable<TEntity> SelectAll(
        Expression<Func<TEntity, bool>> predicate = null);
    ValueTask<TEntity> SelectByIdAsync(TKey id);
    ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(TEntity entity);
    ValueTask<int> SaveChangesAsync();
}
