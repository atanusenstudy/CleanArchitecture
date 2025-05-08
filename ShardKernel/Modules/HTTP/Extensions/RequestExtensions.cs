using Microsoft.AspNetCore.Http;

namespace ShardKernel.Modules.HTTP.Extensions;

public static class RequestExtensions
{
    public static string GetCompanyId(this HttpRequest request) => request.HttpContext.User.FindFirst("CompanyId")?.Value ?? string.Empty;

    public static int GetCompanyIdInt(this HttpRequest request)
    {
        var companyId = request.GetCompanyId();
        return !int.TryParse(companyId, out var parsedCompanyId) ? 0 : parsedCompanyId;
    }
    
    public static string GetUserId(this HttpRequest request) => request.HttpContext.User.FindFirst("UserId")?.Value ?? string.Empty;

    public static int GetUserIdInt(this HttpRequest request)
    {
        var userId = request.GetUserId();
        return !int.TryParse(userId, out var parsedUserId) ? 0 : parsedUserId;
    }

    public static string GetCorelationId(this HttpRequest request) => request.HttpContext.User.FindFirst("CorrelationId")?.Value ?? string.Empty;
}
