using Persistent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistent.Ef.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
            where TEntity : class, new()
    {
        private readonly IDbContext _context;
        public Repository(IDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Queryable<TEntity>();
        }

        public bool All(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().All(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().Count(predicate);
        }

        public IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().Where(predicate);
        }

        public IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> sortOrder)
        {
            var queryable = AsQueryable().Where(predicate);
            var orderable = new Orderable<TEntity>(queryable);
            sortOrder(orderable);
            return orderable.AsQueryable();
        }

        public IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> sortOrder, int pageIndex, int pageSize)
        {
            int skip = pageIndex * pageSize;
            var queryable = AsQueryable().Where(predicate);
            var orderable = new Orderable<TEntity>(queryable);
            sortOrder(orderable);
            return orderable.AsQueryable()
                .Skip(skip)
                .Take(pageSize);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().First(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().FirstOrDefault(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().Single(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return AsQueryable().SingleOrDefault(predicate);
        }
    }
}
