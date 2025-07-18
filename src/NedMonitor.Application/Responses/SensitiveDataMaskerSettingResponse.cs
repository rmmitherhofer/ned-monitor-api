namespace NedMonitor.Application.Responses;

public class SensitiveDataMaskerSettingResponse
{
    public bool Enabled { get;  set; }
    public List<string> SensitiveKeys { get;  set; }
    public string MaskValue { get;  set; }


}