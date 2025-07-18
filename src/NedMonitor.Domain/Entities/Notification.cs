using Microsoft.Extensions.Logging;
using Zypher.Domain.Core.DomainObjects;
using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Notification : Entity
{
    public DateTime Timestamp { get; private set; }
    public LogLevel LogLevel { get; private set; }
    public string? Key { get; private set; }
    public string Value { get; private set; }
    public string? Detail { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public string CorrelationId { get; private set; }
    public Guid LogId { get; private set; }

    protected Notification() { }

    public static NotificationInfoBuilder Create(Guid id, DateTime timestamp, LogLevel logLevel, string value) => new(id, timestamp, logLevel, value);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        CorrelationId = log.CorrelationId;
    }

    public class NotificationInfoBuilder
    {
        private readonly Notification _notification;

        public NotificationInfoBuilder(Guid id, DateTime timestamp, LogLevel logLevel, string value)
        {
            if (id == Guid.Empty)
                throw new DomainException("Id must be a valid GUID.");
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Value is required.");

            _notification = new Notification
            {
                Id = id,
                Timestamp = timestamp,
                LogLevel = logLevel,
                Value = value
            };
        }

        public NotificationInfoBuilder WithKey(string? key)
        {
            _notification.Key = key;
            return this;
        }

        public NotificationInfoBuilder WithDetail(string? detail)
        {
            _notification.Detail = detail;
            return this;
        }

        public Notification Build() => _notification;
    }

    public override string ToString()
    {
        return $"{Timestamp:u} [{LogLevel}] {Key ?? "NoKey"}: {Value}";
    }
}
