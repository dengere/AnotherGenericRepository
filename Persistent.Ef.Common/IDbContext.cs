using System.Linq;

namespace Persistent.Ef.Common
{
    public interface IDbContext
    {
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;
    }
}
