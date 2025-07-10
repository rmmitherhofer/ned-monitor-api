﻿namespace NedMonitor.Domain.Enums;

/// <summary>
/// Defines the execution mode for SnapTrace log processing,
/// determining which types of events will be captured and sent.
/// </summary>
public enum SnapTraceExecutionMode
{
    /// <summary>
    /// Disables SnapTrace logging. No logs, notifications, or exceptions will be processed.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Captures only exceptions during execution.
    /// </summary>
    ExceptionsOnly = 1,

    /// <summary>
    /// Captures both domain/application notifications and exceptions.
    /// </summary>
    NotificationsAndExceptions = 2,

    /// <summary>
    /// Captures logs, notifications, and exceptions (full monitoring).
    /// </summary>
    Full = 3
}