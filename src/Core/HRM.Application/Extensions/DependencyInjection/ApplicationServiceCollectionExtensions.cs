using FluentValidation;
using HRM.Application.Common.Interfaces.Services;
using HRM.Application.Common.Services;
using HRM.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRM.Application.Extensions.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register Commands and Queries
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register Mappings
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register Validations
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register Pipeline Behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        // Register Services
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}
