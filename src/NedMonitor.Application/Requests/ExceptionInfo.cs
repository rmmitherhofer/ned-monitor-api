namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents detailed information about an exception.
/// </summary>
public class ExceptionInfo
{
    /// <summary>
    /// The type or class name of the exception.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// The exception message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Optional stack trace or tracer information.
    /// </summary>
    public string? Tracer { get; set; }

    /// <summary>
    /// Optional detailed additional information about the exception.
    /// </summary>
    public string? InnerException { get; set; }

    /// <summary>
    /// Timestamp (UTC) when the exception was captured.
    /// </summary>
    public DateTime TimestampUtc { get; set; }

    /// <summary>
    /// Optional context or source where the exception was thrown (e.g., class/method name).
    /// </summary>
    public string? Source { get; set; }
}
