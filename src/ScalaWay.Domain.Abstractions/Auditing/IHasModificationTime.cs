namespace ScalaWay.Domain.Abstractions.Auditing
{
    /// <summary>
    /// A standard interface to add LastModificationTime property to a class.
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// The last modified time for this entity.
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }

    public interface IHasModificationTime<TIdentityKey> : IHasModificationTime
    {
        TIdentityKey? LastModifierId { get; set; }
    }
}