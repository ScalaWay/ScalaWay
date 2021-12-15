using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.Evaluators;

namespace ScalaWay.Specification.EntityFrameworkCore.Evaluators
{
    /// <inheritdoc/>
    public class SpecificationEvaluator : ISpecificationEvaluator
    {
        // Will use singleton for default configuration.
        // Yet, it can be instantiated if necessary, with default or provided evaluators.
        public static SpecificationEvaluator Default { get; } = new SpecificationEvaluator();

        private readonly List<IEvaluator> evaluators = new List<IEvaluator>();

        public SpecificationEvaluator()
        {
            this.evaluators.AddRange(new IEvaluator[]
            {
                WhereEvaluator.Instance,
                SearchEvaluator.Instance,
                IncludeEvaluator.Instance,
                OrderEvaluator.Instance,
                PaginationEvaluator.Instance,
                AsNoTrackingEvaluator.Instance,
            });
        }

        public SpecificationEvaluator(IEnumerable<IEvaluator> evaluators)
        {
            this.evaluators.AddRange(evaluators);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> inputQuery, ISpecification<T, TResult> specification) where T : class
        {
            inputQuery = GetQuery(inputQuery, (ISpecification<T>)specification);

#pragma warning disable CS8604 // Possible null reference argument.
            return inputQuery.Select(specification.Selector);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, ISpecification<T> specification, bool evaluateCriteriaOnly = false) where T : class
        {
            var evals = evaluateCriteriaOnly ? this.evaluators.Where(x => x.IsCriteriaEvaluator) : this.evaluators;

            foreach (var evaluator in evals)
            {
                inputQuery = evaluator.GetQuery(inputQuery, specification);
            }

            return inputQuery;
        }
    }
}