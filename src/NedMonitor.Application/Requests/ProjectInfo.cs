using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Requests;


/// <summary>
/// Contains basic information about a project.
/// </summary>
public class ProjectInfo
{
    /// <summary>
    /// Unique identifier for the project.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Type of the project (defined by the <see cref="Type"/> enum).
    /// </summary>
    public ProjectType Type { get; set; }

    /// <summary>
    /// Name of the project, automatically obtained from the entry assembly.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Defines the execution mode settings that control how NedMonitor behaves during runtime,
    /// such as which features to enable (e.g., logging, notifications, exceptions).
    /// </summary>
    public ExecutionModeSettingsInfo ExecutionMode { get; set; }

    /// <summary>
    /// Configuration settings related to HTTP request and response logging.
    /// </summary>
    public HttpLoggingSettingsInfo? HttpLogging { get; set; }

    /// <summary>
    /// Configuration options for masking sensitive data in logs, such as passwords or tokens.
    /// </summary>
    public SensitiveDataMaskerSettingsInfo? SensitiveDataMasking { get; set; }

    /// <summary>
    /// Settings for capturing and handling exceptions during request processing.
    /// </summary>
    public ExceptionsSettingsInfo? Exceptions { get; set; }

    /// <summary>
    /// Settings related to database interceptors for logging EF and Dapper queries.
    /// </summary>
    public DataInterceptorsSettingsInfo? DataInterceptors { get; set; }

    /// <summary>
    /// Defines the minimum log level to be captured and stored during a request lifecycle.
    /// Log entries below this level will be ignored.
    /// </summary>
    public LogLevel MinimumLogLevel { get; set; }
}


