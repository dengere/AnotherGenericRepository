namespace Persistent.Common
{
    public enum EntityItemState
    {
        Detached = 0,
        Unchanged = 1,
        Deleted = 2,
        Modified = 3,
        Added = 4
    }
    public interface IEntityEntry<TEntity>
    {
        TEntity Entity { get; }
        EntityItemState State { get; }
    }

    public class EntityEntry<TEntity> : IEntityEntry<TEntity>
    {
        private TEntity _entity;
        private EntityItemState _state;

        public EntityEntry(TEntity entity, EntityItemState state)
        {
            State = state;
            Entity = entity;
        }
        public TEntity Entity
        {
            get
            {
                return _entity;
            }
            private set
            {
                _entity = value;
            }
        }

        public EntityItemState State
        {
            get
            {
                return _state;
            }
            private set
            {
                _state = value;
            }
        }
    }
}
