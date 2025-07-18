using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Responses;

public class ProjectResponse
{
    public Guid Id { get; set; }
    public ProjectType Type { get; set; }
    public string Name { get; set; }
    public ExecutionModeSettingResponse ExecutionMode { get; set; }
    public HttpLoggingSettingResponse? HttpLogging { get; set; }
    public SensitiveDataMaskerSettingResponse? SensitiveDataMasking { get; set; }
    public ExceptionsSettingResponse? Exceptions { get; set; }
    public DataInterceptorsSettingResponse? DataInterceptors { get; set; }
    public LogLevel MinimumLogLevel { get; set; }

}
