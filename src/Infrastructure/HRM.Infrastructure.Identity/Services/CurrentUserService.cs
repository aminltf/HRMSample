#nullable disable

using HRM.Application.Common.Interfaces.Services.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HRM.Infrastructure.Identity.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var userId = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userId, out var id) ? id : null;
        }
    }

    public string UserName =>
            _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

    public string Role =>
            _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
}
