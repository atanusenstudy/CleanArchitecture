using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ShardKernel.Modules.DB.UnitOfWork;

public interface IUnitOfWork<out TContext> where TContext : DbContext
{
    TContext Context { get; }
    Task<IDbContextTransaction> CreateTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}