namespace IdentityService.Domain.Abstractions
{
    public interface IAggregate<T> : IEntity<T>, IAggregate
    {
    }

    public interface IAggregate
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
