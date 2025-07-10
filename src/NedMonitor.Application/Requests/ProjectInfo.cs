using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Requests;


/// <summary>
/// Contains basic information about a project.
/// </summary>
public class ProjectInfo
{
    /// <summary>
    /// Unique identifier of the project.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the project.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Type of the project.
    /// </summary>
    public ProjectType Type { get; set; }

    /// <summary>
    /// Maximum size of the response body to capture, in megabytes.
    /// </summary>
    public int MaxResponseBodySizeInMb { get; set; }

    /// <summary>
    /// Indicates whether to capture the response body for logging.
    /// </summary>
    public bool CaptureResponseBody { get; set; }

    /// <summary>
    /// Indicates whether the request and response payload should be written to the console output.
    /// Useful for debugging during development.
    /// </summary>
    public bool WritePayloadToConsole { get; set; }

    /// <summary>
    /// Enables or disables the NedMonitor entirely.
    /// </summary>
    public bool EnableNedMonitor { get; set; } = true;

    /// <summary>
    /// Enables capturing of unhandled exceptions.
    /// </summary>
    public bool EnableMonitorExceptions { get; set; } = true;

    /// <summary>
    /// Enables capturing of domain or validation notifications.
    /// </summary>
    public bool EnableMonitorNotifications { get; set; }

    /// <summary>
    /// Enables capturing of application logs (e.g., console logs).
    /// </summary>
    public bool EnableMonitorLogs { get; set; }

    /// <summary>
    /// Enables logging of outgoing HttpClient requests.
    /// </summary>
    public bool EnableMonitorHttpRequests { get; set; }

    /// <summary>
    /// List of keywords used to identify and mask sensitive data (e.g., passwords, tokens, secrets) in logs.
    /// </summary>
    public List<string> SensitiveKeys { get; set; }
    /// <summary>
    /// A list of fully qualified exception type names that should be treated as expected exceptions
    /// (i.e., not considered errors and may not trigger error logging).
    /// </summary>
    public List<string> ExpectedExceptions { get; set; }
}


