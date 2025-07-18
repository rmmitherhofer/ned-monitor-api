using Microsoft.Extensions.Logging;

namespace NedMonitor.Application.Responses;

public class LogEntryResponse
{
    public string LogCategory { get; set; }
    public LogLevel LogSeverity { get; set; }
    public string LogMessage { get; set; }
    public string? MemberType { get; set; }
    public string? MemberName { get; set; }
    public int SourceLineNumber { get; set; }
    public DateTime TimestampUtc { get; set; }
    public string CorrelationId { get; set; }
}
