using System.Linq;

namespace Persistent.Ef.Common
{
      public interface IEntityEntry<TEntity>
    {
        TEntity Entity { get; }
        EntityItemState State { get; set; }
    }

    public interface IDbContext
    {
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;
        IEntityEntry<TEntity> Add<TEntity>(TEntity entity, MethodBehavior behavior = MethodBehavior.IncludeDependents) where TEntity : class;
        IEntityEntry<TEntity> Attach<TEntity>(TEntity entity, MethodBehavior behavior = MethodBehavior.IncludeDependents) where TEntity : class;
        IEntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        IEntityEntry<TEntity> Update<TEntity>(TEntity entity, MethodBehavior behavior = MethodBehavior.IncludeDependents) where TEntity : class;
    }
}
