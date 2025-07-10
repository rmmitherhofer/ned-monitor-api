using NedMonitor.Api.Configurations;

namespace NedMonitor.Api;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiConfig(builder.Configuration, builder.Environment);

        var app = builder.Build();

        app.UseApiConfig();

        app.Run();
    }
}
