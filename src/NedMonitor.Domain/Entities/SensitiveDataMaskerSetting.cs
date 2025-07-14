namespace NedMonitor.Domain.Entities;

public class SensitiveDataMaskerSetting
{
    public bool Enabled { get; private set; }
    public List<string> SensitiveKeys { get; private set; }
    public string MaskValue { get; private set; }

    public SensitiveDataMaskerSetting(bool enabled, List<string> sensitiveKeys, string maskValue)
    {
        Enabled = enabled;
        SensitiveKeys = sensitiveKeys;
        MaskValue = maskValue;
    }
}