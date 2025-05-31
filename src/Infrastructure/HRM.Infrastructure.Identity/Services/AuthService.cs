using HRM.Application.Common.Interfaces.Services.Identity;
using HRM.Domain.Entities.Identity;
using HRM.Shared.Kernel.Settings;
using HRM.Shared.Kernel.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRM.Infrastructure.Identity.Services;

public class AuthService : IAuthService
{
    private readonly JwtSettings _jwtSettings;

    public AuthService(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role.ToRoleName())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: creds);

        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public bool IsPasswordExpired(ApplicationUser user, int expiryDays = 90)
    {
        return !user.PasswordChangedAt.HasValue ||
               (DateTime.UtcNow - user.PasswordChangedAt.Value).TotalDays > expiryDays;
    }
}
