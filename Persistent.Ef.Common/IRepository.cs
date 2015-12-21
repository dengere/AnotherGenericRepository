using System;
using System.Linq.Expressions;

namespace Persistent.Ef.Common
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
    }
}
