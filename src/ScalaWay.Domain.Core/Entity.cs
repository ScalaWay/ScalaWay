using ScalaWay.Domain.Abstractions.Entities;

namespace ScalaWay.Domain.Core
{
    /// <summary>
    /// Abstract Entity for all the Business Entities.
    /// </summary>
    public abstract class Entity : IEntity
    {
        public virtual string Id { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}