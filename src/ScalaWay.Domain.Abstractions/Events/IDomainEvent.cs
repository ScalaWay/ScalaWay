namespace ScalaWay.Domain.Abstractions.Events
{
    /// <summary>
    /// Domain Events enable communications between bounded contexts  by avoiding direct calls.
    /// So a bounded context B1 raise an event and one or more bounded contexts B2…Bn subcribers to this event,
    /// should handle the event  to consume it.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IDomainEvent<TKey>
    {
        TKey Id { get; protected set; }

        DateTime OcurredOn { get; }
    }

    public interface IDomainEvent : IDomainEvent<string>
    {
    }
}