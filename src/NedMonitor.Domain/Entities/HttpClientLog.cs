using System.Net;
using Zypher.Domain.Core.DomainObjects;
using Zypher.Extensions.Core;

namespace NedMonitor.Domain.Entities;

/// <summary>
/// Represents an outgoing HTTP request made via HttpClient, including metadata, payloads, timing, and exceptions.
/// </summary>
public class HttpClientLog : Entity
{
    public DateTime StartTimeUtc { get; init; }
    public DateTime EndTimeUtc { get; init; }
    public string Method { get; init; } = null!;
    public string Url { get; init; } = null!;
    public string? UrlTemplate { get; init; }
    public HttpStatusCode StatusCode { get; init; }

    public object? RequestBody { get; private set; }
    public Dictionary<string, List<string>>? RequestHeaders { get; private set; }

    public object? ResponseBody { get; private set; }
    public Dictionary<string, List<string>>? ResponseHeaders { get; private set; }

    public string? ExceptionType { get; private set; }
    public string? ExceptionMessage { get; private set; }
    public string? StackTrace { get; private set; }
    public string? InnerException { get; private set; }

    public long DurationInMilliseconds => (long)(EndTimeUtc - StartTimeUtc).TotalMilliseconds;

    public Guid LogId { get; private set; }
    public string CorrelationId { get; private set; }
    public ApplicationLog ApplicationLog { get; private set; } = null!;

    private HttpClientLog() { }

    public static HttpClientLogBuilder Create(DateTime startTime, DateTime endTime, string method, string url, string? template, HttpStatusCode statusCode)
        => new(startTime, endTime, method, url, template, statusCode);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        CorrelationId = log.CorrelationId;
        ApplicationLog = log;
    }

    public override string ToString()
    {
        return $"{Method} {Url} - {StatusCode} - {DurationInMilliseconds.GetFormattedTime()}";
    }

    public class HttpClientLogBuilder
    {
        private readonly HttpClientLog _log;

        public HttpClientLogBuilder(DateTime startTime, DateTime endTime, string method, string url, string? template, HttpStatusCode statusCode)
        {
            _log = new HttpClientLog
            {
                StartTimeUtc = startTime,
                EndTimeUtc = endTime,
                Method = method,
                Url = url,
                UrlTemplate = template,
                StatusCode = statusCode
            };
        }

        public HttpClientLogBuilder WithRequest(object? requestBody, Dictionary<string, List<string>>? requestHeaders)
        {
            _log.RequestBody = requestBody;
            _log.RequestHeaders = requestHeaders;
            return this;
        }

        public HttpClientLogBuilder WithResponse(object? responseBody, Dictionary<string, List<string>>? responseHeaders)
        {
            _log.ResponseBody = responseBody;
            _log.ResponseHeaders = responseHeaders;
            return this;
        }

        public HttpClientLogBuilder WithException(string? type, string? message, string? stackTrace, string? innerException)
        {
            _log.ExceptionType = type;
            _log.ExceptionMessage = message;
            _log.StackTrace = stackTrace;
            _log.InnerException = innerException;
            return this;
        }

        public HttpClientLog Build() => _log;
    }
}
