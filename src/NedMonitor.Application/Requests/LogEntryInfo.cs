using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents a single log entry with detailed information.
/// </summary>
public class LogEntryInfo
{
    /// <summary>
    /// Category or source of the log entry.
    /// </summary>
    public string LogCategory { get; set; }

    /// <summary>
    /// Severity level of the log entry.
    /// </summary>

    public LogLevel LogSeverity { get; set; }

    /// <summary>
    /// The log message content.
    /// </summary>
    public string LogMessage { get; set; }

    /// <summary>
    /// The fully qualified type name where the log was generated.
    /// </summary>
    public string? MemberType { get; set; }

    /// <summary>
    /// The name of the method or member generating the log.
    /// </summary>
    public string? MemberName { get; set; }

    /// <summary>
    /// The source code line number where the log was generated.
    /// </summary>
    public int SourceLineNumber { get; set; }

    /// <summary>
    /// Timestamp when the log entry was created.
    /// </summary>
    public DateTime Timestamp { get; set; }
}
