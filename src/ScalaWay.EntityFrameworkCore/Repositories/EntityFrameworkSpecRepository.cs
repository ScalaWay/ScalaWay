using Microsoft.EntityFrameworkCore;
using ScalaWay.Domain.Abstractions.Entities;
using ScalaWay.Domain.Abstractions.Repositories;
using ScalaWay.Specification.Abstractions;
using ScalaWay.Specification.EntityFrameworkCore.Evaluators;
using ScalaWay.Specification.Evaluators;
using ScalaWay.Specification.Exceptions;

namespace ScalaWay.EntityFrameworkCore.Repositories
{
    public abstract class EntityFrameworkSpecRepository<TAggregateRoot> : EntityFrameworkRepository<TAggregateRoot>, IReadableSpecificationRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly ISpecificationEvaluator specificationEvaluator;

        #region Constructors

        protected EntityFrameworkSpecRepository(DbContext dbContext) : base(dbContext)
        {
            specificationEvaluator = SpecificationEvaluator.Default;
        }

        protected EntityFrameworkSpecRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator) : base(dbContext)
        {
            if (specificationEvaluator == null) throw new ArgumentNullException("specificationEvaluator");
            this.specificationEvaluator = specificationEvaluator;
        }

        #endregion Constructors

        #region Protected Methods

        /// <summary>
        /// Filters the entities  of <typeparamref name="T"/>, to those that match the encapsulated query logic of the
        /// <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<TAggregateRoot> ApplySpecification(ISpecification<TAggregateRoot> specification, bool evaluateCriteriaOnly = false)
        {
            return specificationEvaluator
                .GetQuery(this.dbContext.Set<TAggregateRoot>()
                .AsQueryable(), specification, evaluateCriteriaOnly);
        }

        /// <summary>
        /// Filters all entities of <typeparamref name="T" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// <para>
        /// Projects each entity into a new form, being <typeparamref name="TResult" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered projected entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TAggregateRoot, TResult> specification)
        {
            if (specification is null) throw new ArgumentNullException("specification");
            if (specification.Selector is null) throw new SelectorNotFoundException();

            return specificationEvaluator
                .GetQuery(this.dbContext.Set<TAggregateRoot>()
                .AsQueryable(), specification);
        }

        #endregion Protected Methods

        #region Read Query Methods

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification, true).CountAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<List<TAggregateRoot>> FindAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TResult>> FindAsync<TResult>(ISpecification<TAggregateRoot, TResult> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<TAggregateRoot?> FindBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISingleResultSpecification, ISpecification<TAggregateRoot>
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<TResult> FindBySpecAsync<TResult>(ISpecification<TAggregateRoot, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        #endregion Read Query Methods
    }
}