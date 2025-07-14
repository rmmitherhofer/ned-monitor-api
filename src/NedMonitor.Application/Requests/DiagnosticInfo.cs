namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents diagnostic information about the application environment and operations.
/// </summary>
public class DiagnosticInfo
{
    /// <summary>
    /// The memory usage of the application in megabytes.
    /// </summary>
    public double MemoryUsageMb { get; set; }

    /// <summary>
    /// The number of database queries executed.
    /// </summary>
    public int DbQueryCount { get; set; }

    /// <summary>
    /// Indicates whether the cache was hit during the operation.
    /// </summary>
    public bool CacheHit { get; set; }

    /// <summary>
    /// List of dependencies involved in the operation.
    /// </summary>
    public List<DependencyInfo> Dependencies { get; set; }
}
