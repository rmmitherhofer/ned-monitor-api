using System.Net;

namespace NedMonitor.Application.Requests;

public class HttpClientLogInfo
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Method { get; set; }
    public string Url { get; set; }
    public string? TemplateUrl { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object? RequestBody { get; set; }
    public object? ResponseBody { get; set; }
    public Dictionary<string, List<string>>? RequestHeaders { get; set; }
    public Dictionary<string, List<string>>? ResponseHeaders { get; set; }
    public string? ExceptionType { get; set; }
    public string? ExceptionMessage { get; set; }
    public string? StackTrace { get; set; }
    public string? InnerException { get; set; }
}