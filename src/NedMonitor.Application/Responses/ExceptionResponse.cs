namespace NedMonitor.Application.Responses;

public class ExceptionResponse
{
    public string Type { get; set; }
    public string Message { get; set; }
    public string? Tracer { get; set; }
    public string? InnerException { get; set; }
    public DateTime TimestampUtc { get; set; }
    public string? Source { get; set; }
    public string CorrelationId { get; set; }
}
