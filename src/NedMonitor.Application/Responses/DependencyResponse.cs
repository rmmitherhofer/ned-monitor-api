namespace NedMonitor.Application.Responses;

public class DependencyResponse
{
    public string Type { get; set; }
    public string Target { get; set; }
    public bool Success { get; set; }
    public int DurationMs { get; set; }
}
