namespace ScalaWay.Domain.Abstractions.Auditing
{
    public interface IHasExpirationTime
    {
        DateTime ExpirationTime { get; set; }
    }
}