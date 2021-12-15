using ScalaWay.Domain.Abstractions.Events;

namespace ScalaWay.Domain.Core
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
            OcurredOn = DateTime.UtcNow;
        }

        public DateTime OcurredOn { get; }

        string IDomainEvent<string>.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}