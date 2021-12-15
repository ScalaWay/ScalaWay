namespace ScalaWay.Specification.Abstractions
{
    public interface IIncludableSpecificationBuilder<T, out TProperty> : ISpecificationBuilder<T> where T : class
    {
    }
}