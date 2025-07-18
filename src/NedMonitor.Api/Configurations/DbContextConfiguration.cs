using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NedMonitor.Domain.Interfaces;
using NedMonitor.Infra.Data;
using NedMonitor.Infra.Data.Repositories;

namespace NedMonitor.Api.Configurations;

public static class DbContextConfiguration
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddDbContext<NedMonitorContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CNN_DB_NED_MONITOR"));
            options.EnableSensitiveDataLogging(false);
            options.UseLoggerFactory(LoggerFactory.Create(_ => { }));
        });

        services.TryAddScoped<NedMonitorContext>();

        services.AddRepository();

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.TryAddScoped<ILogRepository, LogRepository>();

        return services;
    }
}