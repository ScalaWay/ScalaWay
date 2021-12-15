using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Specification.Builder
{
    public class OrderedSpecificationBuilder<T> : IOrderedSpecificationBuilder<T>
    {
        public Specification<T> Specification { get; }

        public OrderedSpecificationBuilder(Specification<T> specification)
        {
            this.Specification = specification;
        }
    }
}