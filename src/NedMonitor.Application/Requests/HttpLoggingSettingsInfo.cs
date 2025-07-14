using System.Text.Json.Serialization;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Configuration settings related to HTTP request and response logging.
/// </summary>
public class HttpLoggingSettingsInfo
{
    /// <summary>
    /// Indicates whether the request and response payload should be written to the console output.
    /// Useful for debugging during development.
    /// </summary>
    public bool WritePayloadToConsole { get; set; }

    /// <summary>
    /// Indicates whether to capture the response body for logging.
    /// </summary>
    public bool CaptureResponseBody { get; set; }

    /// <summary>
    /// Maximum size of the response body to capture, in megabytes.
    /// </summary>
    public int MaxResponseBodySizeInMb { get; set; } = 1;
}