using Lucius.Data.Abstractions.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ScalaWay.EntityFrameworkCore.Uow
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
    {

        #region Fields
        private bool isDisposed = false;
        private readonly TDbContext dbContext;
        #endregion

        #region Constructor
        public UnitOfWork(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Properties
        public TDbContext DbContext => this.dbContext;
        #endregion

        public virtual async Task<TTransaction> BeginTransactionAsync<TTransaction>(CancellationToken cancellationToken = default)
        {
            return (TTransaction) await this.dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.dbContext.SaveChangesAsync(cancellationToken);
        }

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected async virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                await dbContext.DisposeAsync();
            }

            this.isDisposed = true;
        }

        #endregion Disposable
    }
}