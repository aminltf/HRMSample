using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System.Security.Claims;

namespace HRM.Infrastructure.Logging.Enrichers;

public class HttpContextEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var context = _httpContextAccessor.HttpContext;

        if (context == null)
            return;

        var ip = context?.Connection?.RemoteIpAddress?.ToString();
        var userId = context?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userName = context?.User?.Identity?.Name;

        if (!string.IsNullOrWhiteSpace(ip))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ClientIp", ip));

        if (!string.IsNullOrWhiteSpace(userId))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserId", userId));

        if (!string.IsNullOrWhiteSpace(userName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", userName));
    }
}
