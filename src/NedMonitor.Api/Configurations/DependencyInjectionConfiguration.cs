using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NedMonitor.Application.Commands;
using NedMonitor.Application.Commands.Handlers;
using NedMonitor.Application.Configurations.Profiles;
using NedMonitor.Application.Core;
using NedMonitor.Application.Queries;
using System.Reflection;

namespace NedMonitor.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ResolveDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper()
            .AddHandler()
            .AddQuery()
            .AddDbContextConfig(configuration);

        return services;
    }

    private static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.AddAutoMapper(typeof(EntityToResponseProfile), typeof(FilterRequestToFilterProfile));

        return services;
    }

    private static IServiceCollection AddHandler(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.TryAddScoped<IMediatorHandler, MediatorHandler>();

        services.TryAddScoped<IRequestHandler<AddLogCommand, ValidationResult>, LogCommandHandler>();

        return services;
    }

    private static IServiceCollection AddQuery(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.TryAddScoped<ILogQuery, LogQuery>();

        return services;
    }
}
