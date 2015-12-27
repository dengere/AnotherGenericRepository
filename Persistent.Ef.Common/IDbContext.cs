using System;
using System.Linq;

namespace Persistent.Common
{
    public interface IDbContext : IDisposable
    {
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
