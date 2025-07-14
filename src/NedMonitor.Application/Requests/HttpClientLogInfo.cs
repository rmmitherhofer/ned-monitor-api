using System.Net;

namespace NedMonitor.Application.Requests;

public class HttpClientLogInfo
{
    /// <summary>
    /// The UTC timestamp when the HTTP request was initiated.
    /// </summary>
    public DateTime StartTimeUtc { get; set; }

    /// <summary>
    /// The UTC timestamp when the HTTP request completed (successfully or with failure).
    /// </summary>
    public DateTime EndTimeUtc { get; set; }

    /// <summary>
    /// The HTTP method used (e.g., GET, POST, PUT).
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// The full URL requested by the HttpClient.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The templated URL (if available), used for route parameter abstraction.
    /// </summary>
    public string? TemplateUrl { get; set; }

    /// <summary>
    /// The HTTP status code returned by the response.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// The request body sent with the HTTP call.
    /// </summary>
    public object? RequestBody { get; set; }

    /// <summary>
    /// The response body received from the HTTP call.
    /// </summary>
    public object? ResponseBody { get; set; }

    /// <summary>
    /// The HTTP request headers sent with the call.
    /// </summary>
    public Dictionary<string, List<string>>? RequestHeaders { get; set; }

    /// <summary>
    /// The HTTP response headers received from the call.
    /// </summary>
    public Dictionary<string, List<string>>? ResponseHeaders { get; set; }

    /// <summary>
    /// The type of the exception that occurred during the HTTP call, if any.
    /// </summary>
    public string? ExceptionType { get; set; }

    /// <summary>
    /// The message of the exception thrown, if any.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// The stack trace of the exception thrown, if any.
    /// </summary>
    public string? StackTrace { get; set; }

    /// <summary>
    /// The message of the inner exception, if present.
    /// </summary>
    public string? InnerException { get; set; }
}
