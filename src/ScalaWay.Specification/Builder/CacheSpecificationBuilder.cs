using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Specification.Builder
{
    public class CacheSpecificationBuilder<T> : ICacheSpecificationBuilder<T> where T : class
    {
        public Specification<T> Specification { get; }

        public CacheSpecificationBuilder(Specification<T> specification)
        {
            Specification = specification;
        }
    }
}