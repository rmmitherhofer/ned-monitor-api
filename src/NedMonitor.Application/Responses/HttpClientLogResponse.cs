using System.Net;

namespace NedMonitor.Application.Responses;

public class HttpClientLogResponse
{
    public DateTime StartTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public string Method { get; set; }
    public string Url { get; set; }
    public string? UrlTemplate { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public object? RequestBody { get; set; }
    public IDictionary<string, List<string>>? RequestHeaders { get; set; }
    public object? ResponseBody { get; set; }
    public IDictionary<string, List<string>>? ResponseHeaders { get; set; }
    public string? ExceptionType { get; set; }
    public string? ExceptionMessage { get; set; }
    public string? StackTrace { get; set; }
    public string? InnerException { get; set; }
    public long DurationInMilliseconds { get; set; }
    public string CorrelationId { get; set; }
}
