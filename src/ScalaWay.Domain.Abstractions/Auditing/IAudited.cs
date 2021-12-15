namespace ScalaWay.Domain.Abstractions.Auditing
{
    public interface IAudited : IHasCreationTime, IHasModificationTime
    {
    }

    public interface IAudited<TIdentityKey> :
        IHasCreationTime<TIdentityKey>, IHasModificationTime<TIdentityKey>
    {
    }
}