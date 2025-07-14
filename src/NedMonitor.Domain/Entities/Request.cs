using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Request
{
    public string Id { get; private set; }
    public string HttpMethod { get; private set; }
    public string RequestUrl { get; private set; }
    public string Scheme { get; private set; }
    public string Protocol { get; private set; }
    public bool IsHttps { get; private set; }
    public string QueryString { get; private set; }
    public IReadOnlyDictionary<string, string> RouteValues { get; private set; }
     public string ClientId { get; private set; }
    public IReadOnlyDictionary<string, List<string>> Headers { get; private set; }
    public string? ContentType { get; private set; }
    public long? ContentLength { get; private set; }
    public object? Body { get; private set; }
    public double BodySize { get; private set; }
    public bool IsAjaxRequest { get; private set; }
    public string? IpAddress { get; private set; }

    public UserPlatform UserPlatform { get; private set; }
    private Request() { }

    public static RequestInfoBuilder Create(string requestId, string httpMethod, string requestUrl) => new(requestId, httpMethod, requestUrl);

    public class RequestInfoBuilder
    {
        private readonly Request _request = new();

        public RequestInfoBuilder(string requestId, string httpMethod, string requestUrl)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                throw new DomainException("Id is required.");

            if (string.IsNullOrWhiteSpace(httpMethod))
                throw new DomainException("HttpMethod is required.");

            if (string.IsNullOrWhiteSpace(requestUrl))
                throw new DomainException("RequestUrl is required.");

            _request.Id = requestId;
            _request.HttpMethod = httpMethod;
            _request.RequestUrl = requestUrl;

            _request.Scheme = "http";
            _request.Protocol = "HTTP/1.1";
            _request.IsHttps = false;
            _request.QueryString = "";
            _request.RouteValues = new Dictionary<string, string>();
            _request.ClientId = "";
            _request.Headers = new Dictionary<string, List<string>>();
            _request.ContentType = "";
            _request.ContentLength = null;
            _request.Body = null;
            _request.BodySize = 0;
            _request.IsAjaxRequest = false;
            _request.IpAddress = null;
        }

        public RequestInfoBuilder WithScheme(string scheme)
        {
            _request.Scheme = scheme;
            return this;
        }

        public RequestInfoBuilder WithProtocol(string protocol)
        {
            _request.Protocol = protocol;
            return this;
        }

        public RequestInfoBuilder IsSecure(bool isHttps)
        {
            _request.IsHttps = isHttps;
            return this;
        }

        public RequestInfoBuilder WithQueryString(string queryString)
        {
            _request.QueryString = queryString;
            return this;
        }

        public RequestInfoBuilder WithRouteValues(IDictionary<string, string> routeValues)
        {
            _request.RouteValues = routeValues != null ? new Dictionary<string, string>(routeValues) : [];
            return this;
        }

        public RequestInfoBuilder WithUserAgent(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent)) return this;

            _request.UserPlatform = new(userAgent);

            return this;
        }

        public RequestInfoBuilder WithClientId(string clientId)
        {
            _request.ClientId = clientId;
            return this;
        }

        public RequestInfoBuilder WithHeaders(IDictionary<string, List<string>> headers)
        {
            _request.Headers = headers != null ? new Dictionary<string, List<string>>(headers) : [];
            return this;
        }

        public RequestInfoBuilder WithContentType(string contentType)
        {
            _request.ContentType = contentType;
            return this;
        }

        public RequestInfoBuilder WithContentLength(long? contentLength)
        {
            _request.ContentLength = contentLength;
            return this;
        }

        public RequestInfoBuilder WithBody(object? body)
        {
            _request.Body = body;
            return this;
        }

        public RequestInfoBuilder WithBodySize(double size)
        {
            _request.BodySize = size;
            return this;
        }

        public RequestInfoBuilder IsAjax(bool isAjax)
        {
            _request.IsAjaxRequest = isAjax;
            return this;
        }

        public RequestInfoBuilder WithIpAddress(string? ipAddress)
        {
            _request.IpAddress = ipAddress;
            return this;
        }

        public Request Build() => _request;
    }

    public override string ToString()
    {
        return $"{HttpMethod} {RequestUrl} (Id: {Id})";
    }
}


