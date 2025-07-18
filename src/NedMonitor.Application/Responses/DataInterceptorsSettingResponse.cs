namespace NedMonitor.Application.Responses;

public class DataInterceptorsSettingResponse
{
    public EfInterceptorSettingResponse? EF { get; set; }
    public DapperInterceptorSettingResponse? Dapper { get; set; }
}