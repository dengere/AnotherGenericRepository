using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistent.Common
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> sortOrder);
        IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> sortOrder, int pageIndex, int pageSize);
        IQueryable<TEntity> AsQueryable();
        int Count(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        bool All(Expression<Func<TEntity, bool>> predicate);

    }
}
