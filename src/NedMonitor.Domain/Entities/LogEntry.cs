using Microsoft.Extensions.Logging;
using Zypher.Domain.Core.DomainObjects;
using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class LogEntry : Entity
{
    public string LogCategory { get; private set; }
    public LogLevel LogSeverity { get; private set; }
    public string LogMessage { get; private set; }
    public string? MemberType { get; private set; }
    public string? MemberName { get; private set; }
    public int SourceLineNumber { get; private set; }
    public DateTime TimestampUtc { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public Guid LogId { get; private set; }
    public string CorrelationId { get; private set; }

    protected LogEntry() { }

    public static LogEntryInfoBuilder Create(string category, LogLevel severity, string message, DateTime timestamp)
        => new(category, severity, message, timestamp);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        CorrelationId = log.CorrelationId;
    }

    public class LogEntryInfoBuilder
    {
        private readonly LogEntry _log;

        public LogEntryInfoBuilder(string category, LogLevel severity, string message, DateTime timestamp)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new DomainException("LogCategory is required.");
            if (string.IsNullOrWhiteSpace(message))
                throw new DomainException("LogMessage is required.");

            _log = new LogEntry
            {
                LogCategory = category,
                LogSeverity = severity,
                LogMessage = message,
                TimestampUtc = timestamp
            };
        }

        public LogEntryInfoBuilder WithMemberType(string? memberType)
        {
            _log.MemberType = memberType;
            return this;
        }

        public LogEntryInfoBuilder WithMemberName(string? memberName)
        {
            _log.MemberName = memberName;
            return this;
        }

        public LogEntryInfoBuilder WithSourceLineNumber(int lineNumber)
        {
            _log.SourceLineNumber = lineNumber;
            return this;
        }

        public LogEntry Build() => _log;
    }

    public override string ToString()
    {
        var memberInfo = !string.IsNullOrEmpty(MemberName) ? $"{MemberType}.{MemberName}" : "UnknownMember";
        return $"[{TimestampUtc:u}] [{LogSeverity}] {LogCategory}: {LogMessage} ({memberInfo}:{SourceLineNumber})";
    }
}
