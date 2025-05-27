﻿using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services.Reporting;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories;
using Infrastructure.Services.Reporting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeReportPdfService, EmployeeReportPdfService>();

        return services;
    }
}
