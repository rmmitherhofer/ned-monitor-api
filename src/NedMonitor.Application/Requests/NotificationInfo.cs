using Microsoft.Extensions.Logging;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents a notification log entry with details such as level, key, value, and timestamp.
/// </summary>
public class NotificationInfo
    {
        /// <summary>
        /// Unique identifier of the notification.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Timestamp when the notification was created.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Severity level of the log.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Optional key or category related to the notification.
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// The notification message or value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Optional detailed information about the notification.
        /// </summary>
        public string? Detail { get; set; }
   }

