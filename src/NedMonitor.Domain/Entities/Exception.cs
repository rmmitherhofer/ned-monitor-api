using Zypher.Domain.Core.DomainObjects;
using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Exception : Entity
{
    public string Type { get; private set; }
    public string Message { get; private set; }
    public string? Tracer { get; private set; }
    public string? InnerException { get; private set; }
    public DateTime TimestampUtc { get; private set; }
    public string? Source { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public Guid LogId { get; private set; }
    public string CorrelationId { get; private set; }

    protected Exception() { }

    public static ExceptionInfoBuilder Create(string type, string message, DateTime timestampUtc)
        => new(type, message, timestampUtc);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        CorrelationId = log.CorrelationId;
    }

    public class ExceptionInfoBuilder
    {
        private readonly Exception _exception;

        public ExceptionInfoBuilder(string type, string message, DateTime timestampUtc)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new DomainException("Exception type is required.");
            if (string.IsNullOrWhiteSpace(message))
                throw new DomainException("Exception message is required.");

            _exception = new Exception
            {
                Type = type,
                Message = message,
                TimestampUtc = timestampUtc
            };
        }

        public ExceptionInfoBuilder WithTracer(string? tracer)
        {
            _exception.Tracer = tracer;
            return this;
        }

        public ExceptionInfoBuilder WithInnerException(string? inner)
        {
            _exception.InnerException = inner;
            return this;
        }

        public ExceptionInfoBuilder WithSource(string? source)
        {
            _exception.Source = source;
            return this;
        }

        public Exception Build() => _exception;
    }

    public override string ToString()
    {
        var inner = string.IsNullOrEmpty(InnerException) ? "" : $" | Inner: {InnerException}";
        return $"[{Type}] {Message}{inner}";
    }
}
