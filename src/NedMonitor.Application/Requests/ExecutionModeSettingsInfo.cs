﻿namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents feature flags for enabling or disabling individual NedMonitor features.
/// Allows granular control over what should be logged or monitored.
/// </summary>
public class ExecutionModeSettingsInfo
{
    /// <summary>
    /// Enables or disables the NedMonitor entirely.
    /// </summary>
    public bool EnableNedMonitor { get; set; } = true;

    /// <summary>
    /// Enables capturing of unhandled exceptions.
    /// </summary>
    public bool EnableMonitorExceptions { get; set; } = true;

    /// <summary>
    /// Enables capturing of domain or validation notifications.
    /// </summary>
    public bool EnableMonitorNotifications { get; set; }

    /// <summary>
    /// Enables capturing of application logs (e.g., console logs).
    /// </summary>
    public bool EnableMonitorLogs { get; set; }

    /// <summary>
    /// Enables logging of outgoing HttpClient requests.
    /// </summary>
    public bool EnableMonitorHttpRequests { get; set; }

    /// <summary>
    /// Enables logging and monitoring of database queries (Entity Framework, Dapper, etc.).
    /// </summary>
    public bool EnableMonitorDbQueries { get; set; }
}