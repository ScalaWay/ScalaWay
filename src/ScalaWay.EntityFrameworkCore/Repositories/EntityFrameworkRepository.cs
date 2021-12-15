using Microsoft.EntityFrameworkCore;
using ScalaWay.Domain.Abstractions.Entities;
using ScalaWay.Domain.Abstractions.Repositories;

namespace ScalaWay.EntityFrameworkCore.Repositories
{
    public abstract class EntityFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        protected readonly DbContext dbContext;

        protected EntityFrameworkRepository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Read Methods


        public virtual async Task<TAggregateRoot> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken = default) where TKey : notnull
        {
            return await dbContext
                .Set<TAggregateRoot>()
                .FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public virtual async Task<List<TAggregateRoot>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext
                .Set<TAggregateRoot>()
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext
                .Set<TAggregateRoot>()
                .CountAsync(cancellationToken);
        }

        #endregion Read Methods
    }
}