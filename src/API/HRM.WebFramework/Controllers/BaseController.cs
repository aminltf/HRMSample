using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HRM.WebFramework.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseController<T> : ControllerBase
{
    private IMediator? _mediator;
    private readonly ILogger<T> _logger;

    protected BaseController(ILogger<T> logger) => _logger = logger;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}
