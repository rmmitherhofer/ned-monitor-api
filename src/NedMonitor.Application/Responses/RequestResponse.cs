namespace NedMonitor.Application.Responses;

public class RequestResponse
{
    public string Id { get; set; }
    public string HttpMethod { get; set; }
    public string RequestUrl { get; set; }
    public string Scheme { get; set; }
    public string Protocol { get; set; }
    public bool IsHttps { get; set; }
    public string QueryString { get; set; }
    public IDictionary<string, string> RouteValues { get; set; }
    public string? ClientId { get; set; }
    public IDictionary<string, List<string>> Headers { get; set; }
    public string? ContentType { get; set; }
    public long? ContentLength { get; set; }
    public object? Body { get; set; }
    public double BodySize { get; set; }
    public bool IsAjaxRequest { get; set; }
    public string? IpAddress { get; set; }
    public UserPlatformResponse UserPlatform { get; set; }
}


