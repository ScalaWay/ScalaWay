using ScalaWay.Domain.Abstractions.Entities;

namespace ScalaWay.Domain.Abstractions.Repositories
{
    public interface IWritableRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// Adds an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="T" />.
        /// </returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a set of entities in the database.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a set of entities in the database.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}