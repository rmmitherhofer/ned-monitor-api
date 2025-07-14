using NedMonitor.Domain.Enums;

namespace NedMonitor.Domain.Entities;

public abstract class ORMSetting
{
    public bool Enabled { get; protected set; }

    public List<CaptureOptions>? CaptureOptions { get; protected set; }
    protected ORMSetting(bool enabled, List<CaptureOptions>? captureOptions)
    {
        Enabled = enabled;
        CaptureOptions = captureOptions;
    }
}