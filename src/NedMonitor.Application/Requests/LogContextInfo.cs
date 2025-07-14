using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Requests;


/// <summary>
/// Represents the full context of a request log, including environment, request, response, diagnostics, and exceptions.
/// </summary>
public class LogContextInfo
{
    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the operation started.
    /// </summary>
    public DateTime StartTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the operation ended.
    /// </summary>
    public DateTime EndTimeUtc { get; set; }
    /// <summary>
    /// Attention level of the log.
    /// </summary>
    public LogAttentionLevel LogAttentionLevel { get; set; }

    /// <summary>
    /// The correlation ID for tracking requests across services.
    /// </summary>
    public string CorrelationId { get; set; }

    /// <summary>
    /// The HTTP endpoint path requested.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Elapsed time of the request in milliseconds.
    /// </summary>
    public double TotalMilliseconds { get; set; }
    /// <summary>
    /// Unique identifier for the request trace.
    /// </summary>
    public string TraceIdentifier { get; set; }

    /// <summary>
    /// Category of the detected error, if applicable.
    /// </summary>
    public string ErrorCategory { get; set; }

    /// <summary>
    /// Information about the project generating the log.
    /// </summary>
    public ProjectInfo Project { get; set; }

    /// <summary>
    /// Information about the environment where the application is running.
    /// </summary>
    public EnvironmentInfo Environment { get; set; }

    /// <summary>
    /// Authenticated user information, if available.
    /// </summary>
    public UserInfo User { get; set; }

    /// <summary>
    /// HTTP request information.
    /// </summary>
    public RequestInfo Request { get; set; }

    /// <summary>
    /// HTTP response information.
    /// </summary>
    public ResponseInfo Response { get; set; }

    /// <summary>
    /// Diagnostic data such as memory usage, dependencies, and cache hits.
    /// </summary>
    public DiagnosticInfo Diagnostic { get; set; }

    /// <summary>
    /// Notifications generated during the request processing.
    /// </summary>
    public IEnumerable<NotificationInfo>? Notifications { get; set; }

    /// <summary>
    /// Detailed log entries (messages, levels, sources).
    /// </summary>
    public IEnumerable<LogEntryInfo>? LogEntries { get; set; }

    /// <summary>
    /// Captured exception details during processing.
    /// </summary>
    public IEnumerable<ExceptionInfo>? Exceptions { get; set; }

    /// <summary>
    /// Collection of HTTP client logs representing outbound requests made during the operation.
    /// </summary>
    public IEnumerable<HttpClientLogInfo>? HttpClientLogs { get; set; }

    /// <summary>
    /// Collection of database queries executed during the request lifecycle, including EF and Dapper.
    /// </summary>
    public IEnumerable<DbQueryEntryInfo>? DbQueryEntries { get; set; }
}