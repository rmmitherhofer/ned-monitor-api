namespace NedMonitor.Application.Responses;

public class UserPlatformResponse
{
    public string UserAgent { get; set; }
    public string BrowserName { get; set; }
    public string BrowserVersion { get; set; }
    public string OSName { get; set; }
    public string OSVersion { get; set; }
    public string DeviceType { get; set; }

}