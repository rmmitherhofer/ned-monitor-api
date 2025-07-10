using Common.Core.DomainObjects;
using Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace NedMonitor.Domain.Entities;

public class LogEntry : Entity
{
    public string LogCategory { get; private set; }
    public LogLevel LogSeverity { get; private set; }
    public string LogMessage { get; private set; }
    public string? MemberType { get; private set; }
    public string? MemberName { get; private set; }
    public int SourceLineNumber { get; private set; }
    public DateTime Timestamp { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public Guid LogId { get; private set; }

    private LogEntry() { }

    public static LogEntryInfoBuilder Create(string category, LogLevel severity, string message, DateTime timestamp)
        => new(category, severity, message, timestamp);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        ApplicationLog = log;
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
                Timestamp = timestamp
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
        return $"[{Timestamp:u}] [{LogSeverity}] {LogCategory}: {LogMessage} ({memberInfo}:{SourceLineNumber})";
    }
}
