using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.EntityFrameworkCore.Extensions;
using ScalaWay.Specification.Evaluators;

namespace ScalaWay.Specification.EntityFrameworkCore.Evaluators
{
    public class SearchEvaluator : IEvaluator
    {
        private SearchEvaluator()
        { }

        public static SearchEvaluator Instance { get; } = new SearchEvaluator();

        public bool IsCriteriaEvaluator { get; } = true;

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            foreach (var searchCriteria in specification.SearchCriterias.GroupBy(x => x.SearchGroup))
            {
                var criterias = searchCriteria.Select(x => (x.Selector, x.SearchTerm));
                query = query.Search(criterias);
            }

            return query;
        }
    }
}