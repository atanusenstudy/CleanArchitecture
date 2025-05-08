using Microsoft.AspNetCore.Http;
using ShardKernel.Modules.HTTP.Extensions;

namespace ShardKernel.Modules.HTTP.CallerContext;

public class CallerContextService : ICallerContext
{
    private readonly Lazy<IHttpContextAccessor> _context;

    public CallerContextService(Lazy<IHttpContextAccessor> context)
    {
        _context = context;
    }

    public int? GetUserId() => _context.Value.HttpContext?.Request.GetUserIdInt();
}
