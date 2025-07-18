using Zypher.Api.Foundation.Configurations;

namespace NedMonitor.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddZypherApiFoundation(configuration, environment);        

        services.ResolveDependency(configuration);

        return services;
    }

    public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(IApplicationBuilder));

        app.UseZypherApiFoundation();

        return app;
    }
}
