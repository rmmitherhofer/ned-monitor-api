namespace NedMonitor.Application.Requests;

/// <summary>
/// Configuration settings related to handling and logging exceptions.
/// </summary>
public class ExceptionsSettingsInfo
{
    /// <summary>
    /// A list of fully qualified exception type names that should be treated as expected exceptions
    /// (i.e., not considered errors and may not trigger error logging).
    /// </summary>
    public List<string> Expected { get; set; }
}