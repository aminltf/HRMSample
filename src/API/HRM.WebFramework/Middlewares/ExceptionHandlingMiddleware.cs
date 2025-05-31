using HRM.Shared.Kernel.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace HRM.WebFramework.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            string result;

            switch (ex)
            {
                case ConflictException conflictEx:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    result = JsonSerializer.Serialize(new { message = conflictEx.Message });
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = JsonSerializer.Serialize(new { message = "خطای سرور رخ داده است." });
                    break;
            }

            await context.Response.WriteAsync(result);
        }
    }
}
