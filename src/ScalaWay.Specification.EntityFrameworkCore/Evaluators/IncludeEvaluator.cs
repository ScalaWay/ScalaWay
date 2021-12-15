using Microsoft.EntityFrameworkCore;
using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.EntityFrameworkCore.Extensions;
using ScalaWay.Specification.Enums;
using ScalaWay.Specification.Evaluators;

namespace ScalaWay.Specification.EntityFrameworkCore.Evaluators
{
    public class IncludeEvaluator : IEvaluator
    {
        private IncludeEvaluator()
        { }

        public static IncludeEvaluator Instance { get; } = new IncludeEvaluator();

        public bool IsCriteriaEvaluator { get; } = false;

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            foreach (var includeString in specification.IncludeStrings)
            {
                query = query.Include(includeString);
            }

            foreach (var includeInfo in specification.IncludeExpressions)
            {
                if (includeInfo.Type == IncludeType.Include)
                {
                    query = query.Include(includeInfo);
                }
                else if (includeInfo.Type == IncludeType.ThenInclude)
                {
                    query = query.ThenInclude(includeInfo);
                }
            }

            return query;
        }
    }
}