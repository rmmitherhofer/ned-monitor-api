using System.Text.Json.Serialization;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents detailed information about an HTTP request.
/// </summary>
public class RequestInfo
{
    /// <summary>
    /// The unique identifier for the request.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The HTTP method used in the request (GET, POST, etc.).
    /// </summary>
    public string HttpMethod { get; set; }

    /// <summary>
    /// The full URL of the request.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The URL scheme (http, https).
    /// </summary>
    public string Scheme { get; set; }

    /// <summary>
    /// The HTTP protocol version.
    /// </summary>
    public string Protocol { get; set; }

    /// <summary>
    /// Indicates if the request uses HTTPS.
    /// </summary>
    public bool IsHttps { get; set; }

    /// <summary>
    /// The query string parameters.
    /// </summary>
    public string QueryString { get; set; }

    /// <summary>
    /// The route values extracted from the request URL.
    /// </summary>
    public IDictionary<string, string> RouteValues { get; set; }

    /// <summary>
    /// The User-Agent header from the request.
    /// </summary>
    public string UserAgent { get; set; }

    /// <summary>
    /// The client identifier making the request.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    /// The HTTP headers included in the request.
    /// </summary>
    public IDictionary<string, List<string>> Headers { get; set; }

    /// <summary>
    /// The content type of the request body.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// The length of the content body, if available.
    /// </summary>
    public long? ContentLength { get; set; }

    /// <summary>
    /// The request body content.
    /// </summary>
    public object? Body { get; set; }

    /// <summary>
    /// The size of the body in bytes.
    /// </summary>
    public double BodySize { get; set; }

    /// <summary>
    /// Indicates if the request was made via AJAX.
    /// </summary>
    public bool IsAjaxRequest { get; set; }
    /// <summary>
    /// The IP address of the request origin.
    /// </summary>
    public string? IpAddress { get; set; }
}
