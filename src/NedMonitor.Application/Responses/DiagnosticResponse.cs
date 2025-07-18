namespace NedMonitor.Application.Responses;

public class DiagnosticResponse
{
    public double MemoryUsageMb { get; set; }
    public int DbQueryCount { get; set; }
    public bool CacheHit { get; set; }
    public IEnumerable<DependencyResponse> Dependencies { get; set; }

}
