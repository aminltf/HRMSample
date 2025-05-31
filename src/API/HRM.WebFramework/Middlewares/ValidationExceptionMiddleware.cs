using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace HRM.WebFramework.Middlewares;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionMiddleware> _logger;

    public ValidationExceptionMiddleware(RequestDelegate next, ILogger<ValidationExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validation error: {Errors}", ex.Errors.Select(e => e.ErrorMessage));

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors.Select(e => new
            {
                Property = e.PropertyName,
                Message = e.ErrorMessage
            });

            var result = JsonSerializer.Serialize(new
            {
                message = "خطا در اعتبارسنجی ورودی",
                errors
            });

            await context.Response.WriteAsync(result);
        }
    }
}
