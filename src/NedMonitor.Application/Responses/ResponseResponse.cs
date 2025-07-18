using System.Net;

namespace NedMonitor.Application.Responses;

public class ResponseResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string ReasonPhrase { get; set; }
    public IReadOnlyDictionary<string, List<string>> Headers { get; set; }
    public object? Body { get; set; }
    public long BodySize { get; set; }

}
