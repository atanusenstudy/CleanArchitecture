using Infrastructure.Data.FullAccess;
using Infrastructure.Data.Readonly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// Add-Migration InitialCreate -Context AppDbContext -StartupProject API -Project Infrastructure
/// Update-Database -Context AppDbContext -StartupProject API -Project Infrastructure
/// </summary>
public static class StartupSetup
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString)); // using SQL Server here

    public static IServiceCollection AddReadonlyDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<ReadonlyAppDbContext>(options =>
            options.UseSqlServer(connectionString)); // using SQL Server here
}