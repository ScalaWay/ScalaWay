using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Specification.Evaluators
{
    public interface IInMemoryEvaluator
    {
        IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> specification);
    }
}