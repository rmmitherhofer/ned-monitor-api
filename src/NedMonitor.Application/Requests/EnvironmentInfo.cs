namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents information about the current runtime environment,
/// including machine name, environment name, application version, and thread ID.
/// </summary>
public class EnvironmentInfo
{
    /// <summary>
    /// The name of the machine where the application is running.
    /// </summary>
    public string MachineName { get; set; }

    /// <summary>
    /// The environment name (e.g., Development, Staging, Production).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The version of the running application.
    /// </summary>
    public string ApplicationVersion { get; set; }

    /// <summary>
    /// The ID of the current managed thread executing the request.
    /// </summary>
    public int ThreadId { get; set; }
}
