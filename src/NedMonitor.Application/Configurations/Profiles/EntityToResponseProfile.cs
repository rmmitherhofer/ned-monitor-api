using AutoMapper;
using NedMonitor.Application.Responses;
using NedMonitor.Domain.Entities;

namespace NedMonitor.Application.Configurations.Profiles;

public class EntityToResponseProfile : Profile
{
    public EntityToResponseProfile()
    {
        CreateMap<ApplicationLog, ApplicationLogResponse>();

        CreateMap<Project, ProjectResponse>();

        CreateMap<Domain.Entities.Environment, EnvironmentResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<Request, RequestResponse>();
        CreateMap<Response, ResponseResponse>();
        CreateMap<Diagnostic, DiagnosticResponse>();
        CreateMap<Notification, NotificationResponse>();
        CreateMap<LogEntry, LogEntryResponse>();
        CreateMap<Domain.Entities.Exception, ExceptionResponse>();
        CreateMap<HttpClientLog, HttpClientLogResponse>();
        CreateMap<DbQueryEntry, DbQueryEntryResponse>();

        CreateMap<ExecutionModeSetting, ExecutionModeSettingResponse>();
        CreateMap<HttpLoggingSetting, HttpLoggingSettingResponse>();
        CreateMap<SensitiveDataMaskerSetting, SensitiveDataMaskerSettingResponse>();
        CreateMap<ExceptionsSetting, ExceptionsSettingResponse>();
        CreateMap<DataInterceptorsSetting, DataInterceptorsSettingResponse>();

        CreateMap<UserPlatform, UserPlatformResponse>();
        CreateMap<Dependency, DependencyResponse>();

        CreateMap<EfInterceptorSetting, EfInterceptorSettingResponse>();
        CreateMap<DapperInterceptorSetting, DapperInterceptorSettingResponse>();
        CreateMap<ORMSetting, ORMSettingResponse>();
    }
}
