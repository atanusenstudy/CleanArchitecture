using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace ShardKernel.Modules.DB.UnitOfWork;
public class BaseUnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    public TContext Context { get; }

    public BaseUnitOfWork(TContext context)
    {
        Context = context;
    }

    public Task<IDbContextTransaction> CreateTransactionAsync() => Context.Database.BeginTransactionAsync();

    public Task CommitAsync() => Context.Database.CommitTransactionAsync();

    public Task RollbackAsync() => Context.Database.RollbackTransactionAsync();
}