using ShardKernel.Modules.DB.Repository;
using ShardKernel.Modules.HTTP.CallerContext;

namespace Infrastructure.Data.FullAccess;

public class Repository<T>(AppDbContext dbContext, ICallerContext context)
    : BaseRepository<T>(dbContext,context) where T : class, IAggregateRoot;
