using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.FullAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
