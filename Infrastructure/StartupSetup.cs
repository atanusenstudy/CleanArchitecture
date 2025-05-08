using Infrastructure.Data.FullAccess;
using Infrastructure.Data.Readonly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) 
        => services.AddDbContext<AppDbContext>(
        options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        b => b.SchemaBehavior(MySqlSchemaBehavior.Translate,(schema,table) => $"{schema ??"dbo"}_{table}")));

    public static void AddReadonlyDbContext(this IServiceCollection services, string connectionString)
        => services.AddDbContext<ReadonlyAppDbContext>(
        options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        b => b.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, table) => $"{schema ?? "dbo"}_{table}")));
}
