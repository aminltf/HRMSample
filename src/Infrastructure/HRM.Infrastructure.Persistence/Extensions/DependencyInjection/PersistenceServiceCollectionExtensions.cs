using HRM.Application.Common.Interfaces.Repositories;
using HRM.Infrastructure.Persistence.Contexts;
using HRM.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure.Persistence.Extensions.DependencyInjection;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register Repositories
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
