using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Specification.Evaluators
{
    public interface IEvaluator
    {
        bool IsCriteriaEvaluator { get; }

        IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class;
    }
}