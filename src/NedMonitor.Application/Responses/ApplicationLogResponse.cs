using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Responses;
public class ApplicationLogResponse
{
    public Guid Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime StartTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public LogAttentionLevel LogAttentionLevel { get; set; }
    public string CorrelationId { get; set; }
    public string Path { get; set; }
    public double TotalMilliseconds { get; set; }
    public string? TraceIdentifier { get; set; }
    public string? ErrorCategory { get; set; }
    public ProjectResponse Project { get; set; }
    public EnvironmentResponse Environment { get; set; }
    public UserResponse User { get; set; }
    public RequestResponse Request { get; set; }
    public ResponseResponse Response { get; set; }
    public DiagnosticResponse Diagnostic { get; set; }
    public IEnumerable<NotificationResponse> Notifications { get; set; }
    public IEnumerable<LogEntryResponse> LogEntries { get; set; }
    public IEnumerable<ExceptionResponse> Exceptions { get; set; }
    public IEnumerable<HttpClientLogResponse> HttpClientLogs { get; set; }
    public IEnumerable<DbQueryEntryResponse> DbQueryEntries { get; set; }

}
