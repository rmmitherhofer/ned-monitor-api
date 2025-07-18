namespace NedMonitor.Application.Responses;
public class DbQueryEntryResponse
{
    public string Provider { get; set; }
    public string Sql { get; set; }
    public string Parameters { get; set; }
    public DateTime ExecutedAtUtc { get; set; }
    public double DurationMs { get; set; }
    public bool Success { get; set; }
    public string? ExceptionMessage { get; set; }
    public IDictionary<string, string>? DbContext { get; set; }
    public string ORM { get; set; }
    public string CorrelationId { get; set; }
}
