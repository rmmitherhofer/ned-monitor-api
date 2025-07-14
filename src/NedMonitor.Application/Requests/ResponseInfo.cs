using System.Net;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents detailed information about an HTTP response.
/// </summary>
public class ResponseInfo
{
    /// <summary>
    /// The HTTP status code returned by the response.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// The reason phrase associated with the status code.
    /// </summary>
    public string ReasonPhrase { get; set; }

    /// <summary>
    /// The HTTP headers included in the response.
    /// </summary>
    public IDictionary<string, List<string>> Headers { get; set; }

    /// <summary>
    /// The body content of the response.
    /// </summary>
    public object? Body { get; set; }

    /// <summary>
    /// The size of the body content in bytes.
    /// </summary>
    public long BodySize { get; set; }
}
