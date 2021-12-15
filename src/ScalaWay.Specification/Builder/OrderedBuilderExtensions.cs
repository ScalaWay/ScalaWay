﻿using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.Enums;
using System.Linq.Expressions;

namespace ScalaWay.Specification.Builder
{
    public static class OrderedBuilderExtensions
    {
        public static IOrderedSpecificationBuilder<T> ThenBy<T>(
            this IOrderedSpecificationBuilder<T> orderedBuilder,
            Expression<Func<T, object?>> orderExpression)
        {
            ((List<(Expression<Func<T, object?>> OrderExpression, OrderType OrderType)>)orderedBuilder.Specification.OrderExpressions)
                .Add((orderExpression, OrderType.ThenBy));

            return orderedBuilder;
        }

        public static IOrderedSpecificationBuilder<T> ThenByDescending<T>(
            this IOrderedSpecificationBuilder<T> orderedBuilder,
            Expression<Func<T, object?>> orderExpression)
        {
            ((List<(Expression<Func<T, object?>> OrderExpression, OrderType OrderType)>)orderedBuilder.Specification.OrderExpressions)
                .Add((orderExpression, OrderType.ThenByDescending));

            return orderedBuilder;
        }
    }
}