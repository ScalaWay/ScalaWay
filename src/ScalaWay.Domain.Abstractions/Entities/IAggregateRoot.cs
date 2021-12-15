namespace ScalaWay.Domain.Abstractions.Entities
{
    /// <summary>
    /// An aggregate root is an aggregate entity that is used to control access and organize objects as a single unit of database work.
    /// The aggregate does not confer any sort of "new" or additional identity for an object.
    /// </summary>
    /// <remarks>
    /// This is a marker interface that should be attached to any database persistence model.
    /// </remarks>
    public interface IAggregateRoot : IEntity
    {
    }

    public interface IAggregateRoot<TKey> : IAggregateRoot, IEntity<TKey>
    {
    }
}