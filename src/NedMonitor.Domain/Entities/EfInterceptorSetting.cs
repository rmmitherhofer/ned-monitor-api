using NedMonitor.Domain.Enums;

namespace NedMonitor.Domain.Entities;

public class EfInterceptorSetting : ORMSetting
{
    public EfInterceptorSetting(bool enabled, List<CaptureOptions>? captureOptions) : base(enabled, captureOptions) { }
}
