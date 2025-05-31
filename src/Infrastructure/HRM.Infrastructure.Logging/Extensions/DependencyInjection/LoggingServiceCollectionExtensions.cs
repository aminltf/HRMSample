using System.Collections.ObjectModel;
using System.Data;
using HRM.Infrastructure.Logging.Enrichers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace HRM.Infrastructure.Logging.Extensions.DependencyInjection;

public static class LoggingServiceCollectionExtensions
{
    public static IServiceCollection AddLoggingDependencies(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<ILogEventEnricher, HttpContextEnricher>();

        return services;
    }

    public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, services, loggerConfig) =>
        {
            var configuration = context.Configuration;

            var sinkOptions = new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                SchemaName = "dbo",
                AutoCreateSqlTable = false
            };

            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Add(StandardColumn.LogEvent);
            columnOptions.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn("UserId", SqlDbType.UniqueIdentifier),
                new SqlColumn("UserName", SqlDbType.NVarChar, dataLength: 256),
                new SqlColumn("ClientIp", SqlDbType.NVarChar, dataLength: 64)
            };

            loggerConfig
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.With(new HttpContextEnricher(services.GetRequiredService<IHttpContextAccessor>()))
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
                .WriteTo.MSSqlServer(
                    connectionString: configuration.GetConnectionString("LoggingConnection"),
                    sinkOptions: sinkOptions,
                    columnOptions: columnOptions,
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    formatProvider: null
                )
                .WriteTo.Seq("http://localhost:5341");
        });

        return hostBuilder;
    }
}
