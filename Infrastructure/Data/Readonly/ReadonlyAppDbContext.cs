using Infrastructure.Data.FullAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Readonly;

public sealed class ReadonlyAppDbContext : AppDbContext
{
    public ReadonlyAppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        //Query tracking will prevent us from Lazy Loading
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        throw new InvalidOperationException("You are trying to make change on Readonly DB");
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
