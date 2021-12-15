﻿using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Specification.Builder
{
    public class IncludableSpecificationBuilder<T, TProperty> : IIncludableSpecificationBuilder<T, TProperty> where T : class
    {
        public Specification<T> Specification { get; }

        public IncludableSpecificationBuilder(Specification<T> specification)
        {
            Specification = specification;
        }
    }
}