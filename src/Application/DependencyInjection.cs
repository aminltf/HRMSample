using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register Queries
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register Mapping
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
