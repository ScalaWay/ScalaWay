using Microsoft.EntityFrameworkCore;
using ScalaWay.Domain.Abstractions.Entities;
using ScalaWay.Domain.Abstractions.Repositories;

namespace ScalaWay.EntityFrameworkCore.Repositories
{
    public abstract class EntityFrameworkWritableSpecRepository<TAggregateRoot> : EntityFrameworkSpecRepository<TAggregateRoot>, IWritableSpecificationRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        protected EntityFrameworkWritableSpecRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #region Create Methods

        public virtual async Task AddAsync(TAggregateRoot entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TAggregateRoot>().Add(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TAggregateRoot> entities, CancellationToken cancellationToken = default)
        {
            await dbContext.AddRangeAsync(entities);
            await SaveChangesAsync(cancellationToken);
        }

        #endregion Create Methods

        #region Update Methods

        public virtual async Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TAggregateRoot> entities, CancellationToken cancellationToken = default)
        {
            dbContext.UpdateRange(entities);
            await SaveChangesAsync(cancellationToken);
        }

        #endregion Update Methods

        #region Delete Methods

        public virtual async Task RemoveAsync(TAggregateRoot entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TAggregateRoot>().Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TAggregateRoot> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TAggregateRoot>().RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }

        #endregion Delete Methods

        #region Persistence Operation Methods

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion Persistence Operation Methods
    }
}