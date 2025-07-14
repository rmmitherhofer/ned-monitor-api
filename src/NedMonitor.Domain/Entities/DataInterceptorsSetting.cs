namespace NedMonitor.Domain.Entities;

public class DataInterceptorsSetting
{
    public EfInterceptorSetting? EF { get; private set; }
    public DapperInterceptorSetting? Dapper { get; private set; }

    public DataInterceptorsSetting(EfInterceptorSetting? eF, DapperInterceptorSetting? dapper)
    {
        EF = eF;
        Dapper = dapper;
    }
}