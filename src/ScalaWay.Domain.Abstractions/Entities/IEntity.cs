namespace ScalaWay.Domain.Abstractions.Entities
{
    /// <summary>
    /// Marker interface.
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// Entity with a generic key identifier.
    /// </summary>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
}