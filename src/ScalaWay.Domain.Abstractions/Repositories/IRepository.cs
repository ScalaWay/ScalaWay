using ScalaWay.Domain.Abstractions.Entities;

namespace ScalaWay.Domain.Abstractions.Repositories
{
    /// <summary>
    /// A repository is a very common pattern for data source abstraction.
    /// You use it to abstract away all the data sources you want. Anything that calls the repository can access data from those sources,
    /// but will never know which sources even exist.
    /// In the domain layer, you won’t actually implement a repository.Instead, you’ll only have a repository interface.
    ///
    /// This allows you to invert the dependency on the layers, making the data layer depend on the domain layer,
    /// instead of the other way around!
    /// </summary>
    /// <typeparam name="TEntity">The type of entity being operated on by this repository</typeparam>
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// Finds all entities of <typeparamref name="T" /> from the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TAggregateRoot}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TAggregateRoot>> FindAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the total number of records.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the
        /// number of elements in the input sequence.
        /// </returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);
    }
}