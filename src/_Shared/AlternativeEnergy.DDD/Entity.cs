using AlternativeEnergy.DDD.Interfaces;

namespace AlternativeEnergy.DDD
{
    public abstract class Entity : IEntity
    {
        private readonly List<IDomainEvent> _events = [];

        public Guid Id { get; set; }
        public int Version { get; protected set; }
        public IReadOnlyList<IDomainEvent>? Events => _events?.AsReadOnly();

        protected Entity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Version = 0;
        }

        public void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any()) Version++;

            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
