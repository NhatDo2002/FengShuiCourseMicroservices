namespace IdentityService.Domain.Abstractions
{
    public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
    {
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToArray();
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            var dequeuedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeuedEvents;
        }
    }
}
