using NedMonitor.Domain.Enums;

namespace NedMonitor.Domain.Entities;

public class DapperInterceptorSetting : ORMSetting
{
    public DapperInterceptorSetting(bool enabled, List<CaptureOptions>? captureOptions) : base(enabled, captureOptions) { }
}