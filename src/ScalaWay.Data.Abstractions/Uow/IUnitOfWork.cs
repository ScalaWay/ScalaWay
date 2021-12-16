namespace Lucius.Data.Abstractions.Uow
{

    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

    public interface IUnitOfWork<out TDbContext> : IUnitOfWork
        where TDbContext : class
    {
        TDbContext DbContext { get;  }

        Task<TTransaction> BeginTransactionAsync<TTransaction>(CancellationToken cancellationToken = default);

    }
}