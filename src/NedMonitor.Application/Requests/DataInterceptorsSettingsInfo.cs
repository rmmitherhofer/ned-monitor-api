namespace NedMonitor.Application.Requests;

/// <summary>
/// Configuration settings for database query interceptors used by NedMonitor.
/// Contains settings for both Entity Framework Core and Dapper interceptors.
/// </summary>
public class DataInterceptorsSettingsInfo
{
    /// <summary>
    /// Settings for the Entity Framework Core interceptor.
    /// </summary>
    public EfInterceptorSettingsInfo? EF { get; set; }

    /// <summary>
    /// Settings for the Dapper interceptor.
    /// </summary>
    public DapperInterceptorSettingsInfo? Dapper { get; set; }
}