using NedMonitor.Domain.Enums;

namespace NedMonitor.Application.Responses;

public abstract class ORMSettingResponse
{
    public bool Enabled { get; set; }

    public List<CaptureOptions>? CaptureOptions { get; set; }

}