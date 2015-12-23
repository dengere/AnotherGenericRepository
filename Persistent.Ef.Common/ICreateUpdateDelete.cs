using System.Collections.ObjectModel;

namespace Persistent.Ef.Common
{
    public interface ICreateUpdateDelete<TEntity> where TEntity : class
    {
        ObservableCollection<TEntity> Local { get; }
        TEntity Add(TEntity entity);
        TEntity Attach(TEntity entity);
        TEntity Remove(TEntity entity);
    }
}