
using Common.Core.DomainObjects;
using Common.Exceptions;
using NedMonitor.Domain.Enums;

namespace NedMonitor.Domain.Entities;


public class ApplicationLog : Entity, IAggregateRoot
{
    public LogAttentionLevel LogAttentionLevel { get; private set; }
    public string CorrelationId { get; private set; }
    public string EndpointPath { get; private set; }
    public long ElapsedMilliseconds { get; private set; }
    public string? TraceIdentifier { get; private set; }
    public string? ErrorCategory { get; private set; }
    public Project Project { get; private set; }
    public Environment Environment { get; private set; }
    public User User { get; private set; }
    public UserPlatform UserPlatform { get; private set; }
    public Request Request { get; private set; }
    public Response Response { get; private set; }
    public Diagnostic Diagnostic { get; private set; }
    public IReadOnlyCollection<Notification> Notifications { get; private set; }
    public IReadOnlyCollection<LogEntry> LogEntries { get; private set; }
    public IReadOnlyCollection<Exception> Exceptions { get; private set; }
    public IReadOnlyCollection<HttpClientLog> HttpClientLogs { get; private set; }
    private ApplicationLog()
    {
        Notifications = [];
        LogEntries = [];
        Exceptions = [];
        HttpClientLogs = [];
    }

    public static ApplicationLogBuilder Create(
        LogAttentionLevel logAttentionLevel,
        string correlationId,
        string endpointPath,
        long elapsedMilliseconds,
        Project project,
        Environment environment,
        User user,
        UserPlatform userPlatform,
        Request request,
        Response response,
        Diagnostic diagnostic)
    {
        return new(
            logAttentionLevel,
            correlationId,
            endpointPath,
            elapsedMilliseconds,
            project,
            environment,
            user,
            userPlatform,
            request,
            response,
            diagnostic);
    }

    public class ApplicationLogBuilder
    {
        private readonly ApplicationLog _log;
        private readonly List<Notification> _notifications = [];
        private readonly List<LogEntry> _logEntries = [];
        private readonly List<Exception> _exceptions = [];
        private readonly List<HttpClientLog> _httpClientLogs = [];

        public ApplicationLogBuilder(
            LogAttentionLevel logAttentionLevel,
            string correlationId,
            string endpointPath,
            long elapsedMilliseconds,
            Project project,
            Environment environment,
            User user,
            UserPlatform userPlatform,
            Request request,
            Response response,
            Diagnostic diagnostic)
        {
            if (string.IsNullOrWhiteSpace(correlationId))
                throw new DomainException("CorrelationId is required");

            if (string.IsNullOrWhiteSpace(endpointPath))
                throw new DomainException("EndpointPath is required");

            if (project == null) throw new DomainException("Project is required");
            if (environment == null) throw new DomainException("Environment is required");
            if (user == null) throw new DomainException("User is required");
            if (request == null) throw new DomainException("Request is required");
            if (response == null) throw new DomainException("Response is required");
            if (diagnostic == null) throw new DomainException("Diagnistic is required");

            _log = new ApplicationLog
            {
                LogAttentionLevel = logAttentionLevel,
                CorrelationId = correlationId,
                EndpointPath = endpointPath,
                ElapsedMilliseconds = elapsedMilliseconds,
                Project = project,
                Environment = environment,
                User = user,
                UserPlatform = userPlatform,
                Request = request,
                Response = response,
                Diagnostic = diagnostic
            };
        }

        public ApplicationLogBuilder WithTraceIdentifier(string? traceIdentifier)
        {
            _log.TraceIdentifier = traceIdentifier;
            return this;
        }

        public ApplicationLogBuilder WithErrorCategory(string? errorCategory)
        {
            _log.ErrorCategory = errorCategory;
            return this;
        }

        public ApplicationLogBuilder AddNotification(Notification notification)
        {
            notification.SetParent(_log);
            _notifications.Add(notification);
            return this;
        }

        public ApplicationLogBuilder AddNotifications(IEnumerable<Notification> notifications)
        {
            foreach (var n in notifications)
                AddNotification(n);
            return this;
        }

        public ApplicationLogBuilder AddLogEntry(LogEntry entry)
        {
            entry.SetParent(_log);
            _logEntries.Add(entry);
            return this;
        }

        public ApplicationLogBuilder AddLogEntries(IEnumerable<LogEntry> entries)
        {
            foreach (var e in entries)
                AddLogEntry(e);
            return this;
        }

        public ApplicationLogBuilder AddException(Exception ex)
        {
            ex.SetParent(_log);
            _exceptions.Add(ex);
            return this;
        }

        public ApplicationLogBuilder AddExceptions(IEnumerable<Exception> exceptions)
        {
            foreach (var e in exceptions)
                AddException(e);
            return this;
        }


        public ApplicationLogBuilder AddHttpClientLog(HttpClientLog  httpClientLog)
        {
            httpClientLog.SetParent(_log);
            _httpClientLogs.Add(httpClientLog);
            return this;
        }

        public ApplicationLogBuilder AddHttpClientLogs(IEnumerable<HttpClientLog> httpClientLogs)
        {
            foreach (var logs in httpClientLogs)
                AddHttpClientLog(logs);
            return this;
        }


        public ApplicationLog Build()
        {
            _log.Notifications = _notifications;
            _log.LogEntries = _logEntries;
            _log.Exceptions = _exceptions;
            _log.HttpClientLogs = _httpClientLogs;
            return _log;
        }
    }
    public override string ToString()
    {
        return $"Log [{Id}] - Level: {LogAttentionLevel} - CorrelationId: {CorrelationId} - Endpoint: {EndpointPath} - CreatedAt: {RegistrationDate}";
    }
}
