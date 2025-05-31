using HRM.Infrastructure.Logging.Extensions.DependencyInjection;
using HRM.Application.Extensions.DependencyInjection;
using HRM.Infrastructure.Identity.Extensions.DependencyInjection;
using HRM.Infrastructure.Persistence.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HRM.WebFramework.Extensions.DependencyInjection;

public static class WebServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IHostBuilder host, IConfiguration configuration)
    {
        // Register Logging
        services.AddLoggingDependencies();
        host.UseCustomSerilog();

        // Register Dependencies Layers
        services
            .AddApplicationDependencies()
            .AddIdentityDependencies(configuration)
            .AddPersistenceDependencies(configuration);

        // Register API Versioning
        services.AddApiVersioningDependencies();

        return services;
    }
}
