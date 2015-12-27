using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Persistent.Common.Ef
{
    public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(string connectionStringName) : base(string.Format("name={0}", connectionStringName))
        {
        }
        public IQueryable<TEntity> Queryable<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntry(entity).State = EntityState.Added;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntry(entity).State = EntityState.Deleted;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntry(entity).State = EntityState.Modified;
        }

        private DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }
    }
}
