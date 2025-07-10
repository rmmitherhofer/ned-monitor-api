using Api.Service.Configurations;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NedMonitor.Application.Commands;
using NedMonitor.Application.Commands.Handlers;
using NedMonitor.Application.Core;
using NedMonitor.Domain.Interfaces;
using NedMonitor.Infra.Data;
using NedMonitor.Infra.Data.Repositories;
using System.Reflection;

namespace NedMonitor.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddCoreApiConfig(configuration, environment);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddHandler()
            .AddRepository(configuration);

        return services;
    }

    public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(IApplicationBuilder));

        app.UseCoreApiConfig();

        return app;
    }

    public static IServiceCollection AddHandler(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.TryAddScoped<IMediatorHandler, MediatorHandler>();

        services.TryAddScoped<IRequestHandler<AddLogCommand, ValidationResult>, LogCommandHandler>();


        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddDbContext<NedMonitorContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CNN_DB_NED_MONITOR"));
            options.EnableSensitiveDataLogging(false);
            options.UseLoggerFactory(LoggerFactory.Create(_ => { }));
        });

        services.TryAddScoped<ILogRepository, LogRepository>();

        services.TryAddScoped<NedMonitorContext>();

        return services;
    }


}
