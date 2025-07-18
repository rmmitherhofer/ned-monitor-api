using Microsoft.Extensions.Logging;

namespace NedMonitor.Application.Responses;

public class NotificationResponse
{
    public DateTime Timestamp { get; set; }
    public LogLevel LogLevel { get; set; }
    public string? Key { get; set; }
    public string Value { get; set; }
    public string? Detail { get; set; }
    public string CorrelationId { get; set; }
}
