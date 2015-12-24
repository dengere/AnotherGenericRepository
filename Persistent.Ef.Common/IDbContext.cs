using System.Linq;

namespace Persistent.Common
{
    //public enum EntityItemState
    //{
    //    Detached = 0,
    //    Unchanged = 1,
    //    Deleted = 2,
    //    Modified = 3,
    //    Added = 4
    //}

    //public enum MethodBehavior
    //{
    //    IncludeDependents = 0,
    //    SingleObject = 1
    //}
    //public interface IEntityEntry<TEntity>
    //{
    //    TEntity Entity { get; }
    //    EntityItemState State { get; set; }
    //}

    public interface IDbContext
    {
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;
        //IEntityEntry<TEntity> Add<TEntity>(TEntity entity, MethodBehavior behavior = MethodBehavior.IncludeDependents) where TEntity : class;
        //IEntityEntry<TEntity> Update<TEntity>(TEntity entity, MethodBehavior behavior = MethodBehavior.IncludeDependents) where TEntity : class;
        //IEntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
    }
}
