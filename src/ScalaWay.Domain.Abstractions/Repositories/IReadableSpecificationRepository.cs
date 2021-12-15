using ScalaWay.Specification.Abstractions;

namespace ScalaWay.Domain.Abstractions.Repositories
{
    public interface IReadableSpecificationRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
        /// <summary>
        /// Finds an entity that matches the encapsulated query logic of the <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="T" />, or <see langword="null"/>.
        /// </returns>
        Task<TAggregateRoot?> FindBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISingleResultSpecification, ISpecification<TAggregateRoot>;

        /// <summary>
        /// Finds an entity that matches the encapsulated query logic of the <paramref name="specification"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="TResult" />.
        /// </returns>
        Task<TResult> FindBySpecAsync<TResult>(ISpecification<TAggregateRoot, TResult> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds all entities of <typeparamref name="TAggregateRoot" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TAggregateRoot}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TAggregateRoot>> FindAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds all entities of <typeparamref name="TAggregateRoot" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// <para>
        /// Projects each entity into a new form, being <typeparamref name="TResult" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TResult}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TResult>> FindAsync<TResult>(ISpecification<TAggregateRoot, TResult> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a number that represents how many entities satisfy the encapsulated query logic
        /// of the <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the
        /// number of elements in the input sequence.
        /// </returns>
        Task<int> CountAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);
    }
}