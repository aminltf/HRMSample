using HRM.Application.Common.Interfaces.Repositories.Identity;
using HRM.Application.Common.Interfaces.Services.Identity;
using HRM.Domain.Entities.Identity;
using HRM.Infrastructure.Identity.Contexts;
using HRM.Infrastructure.Identity.Repositories;
using HRM.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure.Identity.Extensions.DependencyInjection;

public static class IdentityServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        // Register Identity Core
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();

        // Register Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Register Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Register JWT Settings
        services.AddJwtAuthentication(configuration);

        return services;
    }
}
