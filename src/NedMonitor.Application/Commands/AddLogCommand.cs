using FluentValidation;
using NedMonitor.Application.Core;
using NedMonitor.Application.Requests;
using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Commands;

public class AddLogCommand : Command
{
    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the operation started.
    /// </summary>
    public DateTime StartTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the operation ended.
    /// </summary>
    public DateTime EndTimeUtc { get; set; }
    /// <summary>
    /// Attention level of the log.
    /// </summary>
    public LogAttentionLevel LogAttentionLevel { get; set; }

    /// <summary>
    /// The correlation ID for tracking requests across services.
    /// </summary>
    public string CorrelationId { get; set; }

    /// <summary>
    /// The HTTP endpoint path requested.
    /// </summary>
    public string EndpointPath { get; set; }

    /// <summary>
    /// Elapsed time of the request in milliseconds.
    /// </summary>
    public double TotalMilliseconds { get; set; }
    /// <summary>
    /// Unique identifier for the request trace.
    /// </summary>
    public string? TraceIdentifier { get; set; }

    /// <summary>
    /// Category of the detected error, if applicable.
    /// </summary>
    public string? ErrorCategory { get; set; }

    /// <summary>
    /// Information about the project generating the log.
    /// </summary>
    public ProjectInfo Project { get; set; }

    /// <summary>
    /// Information about the environment where the application is running.
    /// </summary>
    public EnvironmentInfo Environment { get; set; }

    /// <summary>
    /// Authenticated user information, if available.
    /// </summary>
    public UserInfo User { get; set; }

    /// <summary>
    /// HTTP request information.
    /// </summary>
    public RequestInfo Request { get; set; }

    /// <summary>
    /// HTTP response information.
    /// </summary>
    public ResponseInfo Response { get; set; }

    /// <summary>
    /// Diagnostic data such as memory usage, dependencies, and cache hits.
    /// </summary>
    public DiagnosticInfo Diagnostic { get; set; }

    /// <summary>
    /// Notifications generated during the request processing.
    /// </summary>
    public IEnumerable<NotificationInfo> Notifications { get; set; }

    /// <summary>
    /// Detailed log entries (messages, levels, sources).
    /// </summary>
    public IEnumerable<LogEntryInfo> LogEntries { get; set; }

    /// <summary>
    /// Captured exception details during processing.
    /// </summary>
    public IEnumerable<ExceptionInfo> Exceptions { get; set; }

    public IEnumerable<HttpClientLogInfo> HttpClientLogs { get; set; }

    public IEnumerable<DbQueryEntryInfo> DbQueryEntries { get; set; }

    public AddLogCommand(LogContextInfo request)
    {
        StartTimeUtc = request.StartTimeUtc;
        EndTimeUtc = request.EndTimeUtc;
        LogAttentionLevel = request.LogAttentionLevel;
        CorrelationId = request.CorrelationId;
        EndpointPath = request.Path;
        TotalMilliseconds = request.TotalMilliseconds;
        TraceIdentifier = request.TraceIdentifier;
        ErrorCategory = request.ErrorCategory;
        Project = request.Project;
        Environment = request.Environment;
        User = request.User;
        Request = request.Request;
        Response = request.Response;
        Diagnostic = request.Diagnostic;
        Notifications = request.Notifications;
        LogEntries = request.LogEntries;
        Exceptions = request.Exceptions;
        HttpClientLogs = request.HttpClientLogs;
        DbQueryEntries = request.DbQueryEntries;
    }

    public override bool IsValid()
    {
        ValidationResult = new AddLogValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class AddLogValidation : AbstractValidator<AddLogCommand>
    {
        public AddLogValidation()
        {
            RuleFor(l => l.CorrelationId)
                .NotEmpty()
                .WithMessage("CorrelationId is required for tracking distributed requests.");

            RuleFor(l => l.EndpointPath)
                .NotEmpty()
                .WithMessage("Path is required to identify the request target.");

            RuleFor(l => l.Project)
                .NotNull()
                .WithMessage("Project information must be provided.")
                .DependentRules(() =>
                {
                    RuleFor(l => l.Project.Id)
                        .NotEmpty()
                        .WithMessage("Project.Id is required.");

                    RuleFor(l => l.Project.Name)
                        .NotEmpty()
                        .WithMessage("Project.Name is required.");

                    RuleFor(l => l.Project.Type)
                        .NotEqual((ProjectType)0)
                        .WithMessage("Project.Type must be a valid enum value.");
                });

            RuleFor(l => l.Request)
                .NotNull()
                .WithMessage("Request details must be provided.")
                .DependentRules(() =>
                {
                    RuleFor(l => l.Request.Id)
                        .NotEmpty()
                        .WithMessage("Request.Id is required.");

                    RuleFor(l => l.Request.Url)
                        .NotEmpty()
                        .WithMessage("Request.RequestUrl is required.");
                });

            RuleFor(l => l.Response)
                .NotNull()
                .WithMessage("Response details must be provided.")
                .DependentRules(() =>
                {
                    RuleFor(l => l.Response.StatusCode)
                        .NotEmpty()
                        .WithMessage("Response.StatusCode is required.");
                });

            RuleFor(l => l.LogAttentionLevel)
                .IsInEnum()
                .WithMessage("LogAttentionLevel must be a valid enum value.");

            RuleFor(l => l.TotalMilliseconds)
                .GreaterThanOrEqualTo(0)
                .WithMessage("TotalMilliseconds must be zero or greater.");
        }
    }
}