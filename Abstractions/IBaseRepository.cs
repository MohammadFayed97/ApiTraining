namespace Abstractions;

using System;
using System.Linq.Expressions;

public interface IBaseRepository<TEntity>
{
    IQueryable<TEntity> FindAll();
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
