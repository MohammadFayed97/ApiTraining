namespace Repositories;

using Abstractions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context) => _context = context;

    public virtual void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public virtual void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    public virtual IQueryable<TEntity> FindAll() => _context.Set<TEntity>();

    public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression);

    public virtual void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
}