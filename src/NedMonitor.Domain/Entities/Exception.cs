using Common.Core.DomainObjects;
using Common.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Exception : Entity
{
    public string Type { get; private set; }
    public string Message { get; private set; }
    public string? Tracer { get; private set; }
    public string? InnerException { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public Guid LogId { get; private set; }

    private Exception() { }

    public static ExceptionInfoBuilder Create(string type, string message)
        => new(type, message);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        ApplicationLog = log;
    }

    public class ExceptionInfoBuilder
    {
        private readonly Exception _exception;

        public ExceptionInfoBuilder(string type, string message)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new DomainException("Exception type is required.");
            if (string.IsNullOrWhiteSpace(message))
                throw new DomainException("Exception message is required.");

            _exception = new Exception
            {
                Type = type,
                Message = message
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

        public Exception Build() => _exception;
    }

    public override string ToString()
    {
        var inner = string.IsNullOrEmpty(InnerException) ? "" : $" | Inner: {InnerException}";
        return $"[{Type}] {Message}{inner}";
    }
}
