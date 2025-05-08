using System.Text.RegularExpressions;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShardKernel.Modules.DB.Entity;
using ShardKernel.Modules.DB.Extensions;
using ShardKernel.Modules.HTTP.CallerContext;

namespace ShardKernel.Modules.DB.Repository;
public abstract class BaseRepository<T> : RepositoryBase<T>, IRepository<T>, IReadRepository<T> where T : class, IAggregateRoot
{
    private DbContext Context { get; }
    private const string GlobalTotalCountHackSelector = $"COUNT(*) OVER() AS {nameof(IGlobalTotalCountHack.GlobalTotalCountHack)}";

    protected BaseRepository(DbContext dbContext, ICallerContext? callerContext, ISpecificationEvaluator evaluator) : base(dbContext,
        evaluator)
    {
        Context = dbContext;

        dbContext.SavingChanges += (sender, args) =>
        {
            var userId = callerContext?.GetUserId();
            var addedEntries = dbContext.ChangeTracker.Entries()
                .Where(e => e is { Entity: IAuditable, State: EntityState.Added })
                .Select(e => (IAuditable)e.Entity);

            foreach (var entry in addedEntries)
            {
                entry.CreatedAt = DateTime.UtcNow;
                entry.CreatedBy = userId;
                entry.UpdatedAt = DateTime.UtcNow;
                entry.UpdatedBy = userId;
            }

            var updatedEntries = dbContext.ChangeTracker.Entries()
                .Where(e => e is { Entity: IAuditable, State: EntityState.Modified })
                .Select(e => (IAuditable)e.Entity);

            foreach (var entry in updatedEntries)
            {
                entry.UpdatedAt = DateTime.UtcNow;
                entry.UpdatedBy = userId;
            }
        };
    }

    protected BaseRepository(DbContext dbContext, ICallerContext? callerContext) : this(dbContext,
        callerContext,
        SpecificationEvaluator.Default)
    {
    }

    /// <summary>
    /// This is an optimization technique for cases when you NEED the total.
    /// Consider using pageSize+1 and treat this +1 as "HasMore" instead.
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<(List<TResult> Items, int Total)> ListWithCountAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default) where TResult : IGlobalTotalCountHack
    {
        var query = ApplySpecification(specification);

        var queryString = query.ToQueryString();
        queryString = Regex.Replace(queryString,
            $@"(?is)(?<=\bSELECT\b)(?<before>.*?)(?<hack>(?:,\s*)?[^,]*{nameof(IGlobalTotalCountHack.GlobalTotalCountHack)}[^,]*(?:,\s*)?)?(?<after>.*)(?=\bFROM\b)",
            m => $"{m.Groups["before"].Value} {GlobalTotalCountHackSelector},{m.Groups["after"].Value}",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        var res = await Context.Database.SqlQueryRaw<TResult>(queryString).ToListAsync(cancellationToken);

        return (res, res.FirstOrDefault()?.GlobalTotalCountHack ?? 0);
    }
}