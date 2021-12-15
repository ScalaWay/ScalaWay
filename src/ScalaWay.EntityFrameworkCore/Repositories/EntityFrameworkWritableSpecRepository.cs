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

        public virtual async Task<TAggregateRoot> AddAsync(TAggregateRoot entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TAggregateRoot>().Add(entity);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual Task<TAggregateRoot> AddRangeAsync(IEnumerable<TAggregateRoot> entities, CancellationToken cancellationToken = default)
        {
            // todo
            throw new NotImplementedException();
        }

        #endregion Create Methods

        #region Update Methods

        public virtual async Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync(cancellationToken);
        }

        public Task UpdateRangeAsync(IEnumerable<TAggregateRoot> entities, CancellationToken cancellationToken = default)
        {
            // todo
            throw new NotImplementedException();
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