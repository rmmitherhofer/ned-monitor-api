using System.Net;

namespace NedMonitor.Domain.Entities;

public class Response
{
    public HttpStatusCode StatusCode { get; private set; }
    public string ReasonPhrase { get; private set; }
    public IReadOnlyDictionary<string, List<string>> Headers { get; private set; }
    public object? Body { get; private set; }
    public long BodySize { get; private set; }
    private Response()
    {
        Headers = new Dictionary<string, List<string>>();
        ReasonPhrase = string.Empty;
    }

    public static ResponseInfoBuilder Create(HttpStatusCode statusCode) => new(statusCode);

    public class ResponseInfoBuilder
    {
        private readonly Response _response = new();

        public ResponseInfoBuilder(HttpStatusCode statusCode)
        {
            _response.StatusCode = statusCode;
            _response.BodySize = 0;
            _response.Headers = new Dictionary<string, List<string>>();
            _response.ReasonPhrase = statusCode.ToString();
        }

        public ResponseInfoBuilder WithReasonPhrase(string reasonPhrase)
        {
            _response.ReasonPhrase = reasonPhrase;
            return this;
        }

        public ResponseInfoBuilder WithHeaders(IDictionary<string, List<string>> headers)
        {
            _response.Headers = headers != null ? new Dictionary<string, List<string>>(headers) : [];
            return this;
        }

        public ResponseInfoBuilder WithBody(object? body)
        {
            _response.Body = body;
            return this;
        }

        public ResponseInfoBuilder WithBodySize(long bodySize)
        {
            _response.BodySize = bodySize;
            return this;
        }

        public Response Build() => _response;
    }

    public override string ToString()
    {
        return $"StatusCode: {(int)StatusCode} - {ReasonPhrase}";
    }
}
