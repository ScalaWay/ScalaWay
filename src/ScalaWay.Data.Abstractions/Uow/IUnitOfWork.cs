namespace Lucius.Data.Abstractions.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync();

        Task RollbackAsync();
    }

    public interface IUnitOfWork<TDbContext, TTransaction> : IDisposable
    {
        TDbContext DbContext { get; set; }

        Task<TTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync();

        Task RollbackAsync();
    }
}