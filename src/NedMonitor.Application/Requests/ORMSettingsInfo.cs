using NedMonitor.Domain.Enums;
using System.Text.Json.Serialization;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Base configuration settings for ORM (Object-Relational Mapping) data logging.
/// Used for both EF Core and Dapper interceptors.
/// </summary>
public abstract class ORMSettingsInfo
{
    /// <summary>
    /// Indicates whether the interceptor is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Specifies which parts of the query should be captured (e.g., SQL, parameters, context).
    /// </summary>
    public List<CaptureOptions>? CaptureOptions { get; set; }
}