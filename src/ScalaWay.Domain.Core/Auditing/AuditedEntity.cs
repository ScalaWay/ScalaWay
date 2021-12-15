using ScalaWay.Domain.Abstractions.Entities;

namespace ScalaWay.Domain.Core.Auditing
{
    public abstract class AuditedEntity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}