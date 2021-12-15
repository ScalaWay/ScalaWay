using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.Enums;
using ScalaWay.Specification.Exceptions;

namespace ScalaWay.Specification.Evaluators
{
    public class OrderEvaluator : IEvaluator, IInMemoryEvaluator
    {
        private OrderEvaluator()
        { }

        public static OrderEvaluator Instance { get; } = new OrderEvaluator();

        public bool IsCriteriaEvaluator { get; } = false;

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            if (specification.OrderExpressions != null)
            {
                if (specification.OrderExpressions.Count(x => x.OrderType == OrderType.OrderBy ||
                                                            x.OrderType == OrderType.OrderByDescending) > 1)
                {
                    throw new DuplicateOrderChainException();
                }

                IOrderedQueryable<T>? orderedQuery = null;
                foreach (var orderExpression in specification.OrderExpressions)
                {
                    if (orderExpression.OrderType == OrderType.OrderBy)
                    {
                        orderedQuery = query.OrderBy(orderExpression.KeySelector);
                    }
                    else if (orderExpression.OrderType == OrderType.OrderByDescending)
                    {
                        orderedQuery = query.OrderByDescending(orderExpression.KeySelector);
                    }
                    else if (orderExpression.OrderType == OrderType.ThenBy)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        orderedQuery = orderedQuery.ThenBy(orderExpression.KeySelector);
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                    else if (orderExpression.OrderType == OrderType.ThenByDescending)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        orderedQuery = orderedQuery.ThenByDescending(orderExpression.KeySelector);
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                }

                if (orderedQuery != null)
                {
                    query = orderedQuery;
                }
            }

            return query;
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> specification)
        {
            if (specification.OrderExpressions != null)
            {
                if (specification.OrderExpressions.Count(x => x.OrderType == OrderType.OrderBy ||
                                                            x.OrderType == OrderType.OrderByDescending) > 1)
                {
                    throw new DuplicateOrderChainException();
                }

                IOrderedEnumerable<T>? orderedQuery = null;
                foreach (var orderExpression in specification.OrderExpressions)
                {
                    if (orderExpression.OrderType == OrderType.OrderBy)
                    {
                        orderedQuery = query.OrderBy(orderExpression.KeySelector.Compile());
                    }
                    else if (orderExpression.OrderType == OrderType.OrderByDescending)
                    {
                        orderedQuery = query.OrderByDescending(orderExpression.KeySelector.Compile());
                    }
                    else if (orderExpression.OrderType == OrderType.ThenBy)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        orderedQuery = orderedQuery.ThenBy(orderExpression.KeySelector.Compile());
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                    else if (orderExpression.OrderType == OrderType.ThenByDescending)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        orderedQuery = orderedQuery.ThenByDescending(orderExpression.KeySelector.Compile());
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                }

                if (orderedQuery != null)
                {
                    query = orderedQuery;
                }
            }

            return query;
        }
    }
}