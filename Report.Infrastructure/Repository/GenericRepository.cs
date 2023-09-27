using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Report.Infrastructure.Contexts;

namespace Report.Infrastructure.Repositories;

public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly AppDbContext appDbContext;

    public GenericRepository(AppDbContext appDbContext) =>
        this.appDbContext = appDbContext;

    public async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await this.appDbContext
            .Set<TEntity>()
            .AddAsync(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }


    public  IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> predicate = null) =>
        predicate == null ?
            this.appDbContext.Set<TEntity>() : 
            this.appDbContext.Set<TEntity>().Where(predicate);



    public async ValueTask<TEntity> SelectByIdWithDetailsAsync(
    Expression<Func<TEntity, bool>> expression,
    string[] includes = null)
    {
        IQueryable<TEntity> entities = this.SelectAll();

        foreach (var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }



    public async ValueTask<TEntity> SelectByIdAsync(TKey id) =>
        await this.appDbContext.Set<TEntity>().FindAsync(id);


    


    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = this.appDbContext
            .Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = this.appDbContext
            .Set<TEntity>()
            .Remove(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<int> SaveChangesAsync() =>
        await this.appDbContext
            .SaveChangesAsync();

}