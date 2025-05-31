using HRM.Domain.Entities.Identity;

namespace HRM.Application.Common.Interfaces.Services.Identity;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    bool IsPasswordExpired(ApplicationUser user, int expiryDays = 90);
}
