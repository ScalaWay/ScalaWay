namespace ScalaWay.Domain.Abstractions.Auditing
{
    public interface IHasCreationTime
    {
        DateTime CreateTime { get; set; }
    }

    public interface IHasCreationTime<TIdentityKey> : IHasCreationTime
    {
        TIdentityKey CreatorId { get; set; }
    }
}