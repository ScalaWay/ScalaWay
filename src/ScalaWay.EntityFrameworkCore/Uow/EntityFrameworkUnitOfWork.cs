using Lucius.Data.Abstractions.Uow;
using Microsoft.EntityFrameworkCore.Storage;

namespace ScalaWay.EntityFrameworkCore.Uow
{
    public abstract class EntityFrameworkUnitOfWork<TDbContext> : IUnitOfWork<TDbContext, IDbContextTransaction>
        where TDbContext : ScalaWayDbContext
    {
        private bool isDisposed = false;

        protected EntityFrameworkUnitOfWork(TDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public TDbContext DbContext { get; set; }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await this.DbContext.Database.BeginTransactionAsync();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        #region Disposable

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                Dispose();
            }

            this.isDisposed = true;
        }

        #endregion Disposable
    }
}