using FluentValidation.Results;
using MediatR;
using NedMonitor.Application.Core;
using NedMonitor.Application.Requests;
using NedMonitor.Application.Responses;
using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Interfaces;

namespace NedMonitor.Application.Commands.Handlers;

public class LogCommandHandler : CommandHandler,
    IRequestHandler<AddLogCommand, ValidationResult>
{
    private readonly ILogRepository _logRepository;
    public LogCommandHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<ValidationResult> Handle(AddLogCommand command, CancellationToken cancellationToken)
    {
        if (!command.IsValid())
            return command.ValidationResult;

        var log = BuildApplicationLog(command);

        _logRepository.Add(log);

        return await Commit(_logRepository.UnitOfWork);
    }

    private ApplicationLog BuildApplicationLog(AddLogCommand command) => ApplicationLog.Create(
                command.StartTimeUtc,
                command.EndTimeUtc,
                command.LogAttentionLevel,
                command.CorrelationId,
                command.EndpointPath,
                command.TotalMilliseconds,
                BuildProject(command.Project),
                BuildEnvironment(command.Environment),
                BuildUser(command.User),
                BuildRequest(command.Request),
                BuildResponse(command.Response),
                BuildDiagnostic(command.Diagnostic))
            .WithTraceIdentifier(command.TraceIdentifier)
            .WithErrorCategory(command.ErrorCategory)
            .AddNotifications(BuildNotifications(command.Notifications))
            .AddLogEntries(BuildLogEntries(command.LogEntries))
            .AddExceptions(BuildExceptions(command.Exceptions))
            .AddHttpClientLogs(BuildHttpClientLog(command.HttpClientLogs))
            .AddDbQueryEntries(BuildDbQueryEntries(command.DbQueryEntries))
            .Build();


    private Project BuildProject(ProjectInfo project) => Project.Create(project.Id, project.Name, project.Type)
        .WithExecutionMode(new ExecutionModeSetting(
            project.ExecutionMode.EnableNedMonitor, 
            project.ExecutionMode.EnableMonitorExceptions, 
            project.ExecutionMode.EnableMonitorNotifications, 
            project.ExecutionMode.EnableMonitorLogs, 
            project.ExecutionMode.EnableMonitorHttpRequests, 
            project.ExecutionMode.EnableMonitorDbQueries))
        .WithHttpLogging(new(project.HttpLogging.WritePayloadToConsole, project.HttpLogging.CaptureResponseBody, project.HttpLogging.MaxResponseBodySizeInMb))
        .WithSensitiveDataMasking(new(project.SensitiveDataMasking.Enabled, project.SensitiveDataMasking.SensitiveKeys, project.SensitiveDataMasking.MaskValue))
        .WithExceptions(new(project.Exceptions.Expected))
        .WithDataInterceptors(new(new(project.DataInterceptors.EF.Enabled, project.DataInterceptors.EF.CaptureOptions), new(project.DataInterceptors.Dapper.Enabled, project.DataInterceptors.Dapper.CaptureOptions)))
        .WithMinimumLogLevel(project.MinimumLogLevel)
        .Build();

    private Request BuildRequest(RequestInfo request) => Request.Create(request.Id, request.HttpMethod, request.Url)
        .WithScheme(request.Scheme)
        .WithProtocol(request.Protocol)
        .IsSecure(request.IsHttps)
        .WithQueryString(request.QueryString)
        .WithRouteValues(request.RouteValues)
        .WithUserAgent(request.UserAgent)
        .WithClientId(request.ClientId)
        .WithHeaders(request.Headers)
        .WithContentType(request.ContentType)
        .WithContentLength(request.ContentLength)
        .WithBody(request.Body)
        .WithBodySize(request.BodySize)
        .IsAjax(request.IsAjaxRequest)
        .WithIpAddress(request.IpAddress)
        .Build();

    private Response BuildResponse(ResponseInfo response) => Response.Create(response.StatusCode)
        .WithHeaders(response.Headers)
        .WithReasonPhrase(response.ReasonPhrase)
        .WithBody(response.Body)
        .WithBodySize(response.BodySize)
        .Build();

    private Domain.Entities.Environment BuildEnvironment(EnvironmentInfo environment) => Domain.Entities.Environment.Create(environment.MachineName, environment.Name)
        .WithApplicationVersion(environment.ApplicationVersion)
        .WithThreadId(environment.ThreadId)
        .Build();

    private User BuildUser(UserInfo user)
    {
        if (user.IsAuthenticated)
        {
            return User.Create(user.Id)
                .WithName(user.Name)
                .WithAccount(user.Account)
                .WithAccountCode(user.AccountCode)
                .WithDocument(user.Document)
                .WithRole(user.Roles)
                .WithClaims(user.Claims)
                .WithTenant(user.TenantId)
                .Authenticated(user.AuthenticationType)
                .Build();
        }
        return User.CreateAnonymous();
    }

    private Diagnostic BuildDiagnostic(DiagnosticInfo diagnostic) => Diagnostic.Create()
        .WithMemoryUsage(diagnostic.MemoryUsageMb)
        .WithDbQueryCount(diagnostic.DbQueryCount)
        .WithCacheHit(diagnostic.CacheHit)
        .WithDependencies(BuildDependencies(diagnostic.Dependencies))
        .Build();

    private IEnumerable<LogEntry> BuildLogEntries(IEnumerable<LogEntryInfo> entries)
    {
        if (entries?.Any() is not true) return [];

        return entries.Select(le =>
            LogEntry.Create(le.LogCategory, le.LogSeverity, le.LogMessage, le.TimestampUtc)
                .WithMemberType(le.MemberType)
                .WithMemberName(le.MemberName)
                .WithSourceLineNumber(le.SourceLineNumber)
                .Build());
    }

    private IEnumerable<Domain.Entities.Exception> BuildExceptions(IEnumerable<ExceptionInfo> exceptions)
    {
        if (exceptions?.Any() is not true) return [];

        return exceptions.Select(e =>
            Domain.Entities.Exception.Create(e.Type, e.Message, e.TimestampUtc)
                .WithTracer(e.Tracer)
                .WithInnerException(e.InnerException)
                .WithSource(e.Source)
                .Build());
    }
    private IEnumerable<Notification> BuildNotifications(IEnumerable<NotificationInfo> notifications)
    {
        if (notifications?.Any() is not true) return [];

        return notifications.Select(n =>
            Notification.Create(n.Id, n.Timestamp, n.LogLevel, n.Value)
                .WithKey(n.Key)
                .WithDetail(n.Detail)
                .Build());
    }

    private IEnumerable<Dependency> BuildDependencies(IEnumerable<DependencyInfo> dependencies)
    {
        if (dependencies?.Any() is not true) return [];

        return dependencies.Select(d => new Dependency(d.Type, d.Target, d.Success, d.DurationMs));
    }

    private IEnumerable<DbQueryEntry> BuildDbQueryEntries(IEnumerable<DbQueryEntryInfo> dbQueryEntries)
    {
        if (dbQueryEntries?.Any() is not true) return [];

        return dbQueryEntries.Select(n =>
            DbQueryEntry.Create(n.Provider, n.ExecutedAtUtc, n.DurationMs, n.Success, n.ORM)
                .WithSql(n.Sql)
                .WithParameters(n.Parameters)
                .WithException(n.ExceptionMessage)
                .WithDbContext(n.DbContext)
                .Build());
    }

    private IEnumerable<HttpClientLog> BuildHttpClientLog(IEnumerable<HttpClientLogInfo> httpClientLogs)
    {
        if (httpClientLogs?.Any() is not true) return [];

        return httpClientLogs.Select(l => HttpClientLog.Create(l.StartTimeUtc, l.EndTimeUtc, l.Method, l.Url, l.TemplateUrl, l.StatusCode)
            .WithRequest(l.RequestBody, l.RequestHeaders)
            .WithResponse(l.ResponseBody, l.ResponseHeaders)
            .WithException(l.ExceptionType, l.ExceptionMessage, l.StackTrace, l.InnerException)
            .Build());
    }
}
