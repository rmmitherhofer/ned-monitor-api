namespace NedMonitor.Application.Responses;

public class HttpLoggingSettingResponse
{
    public bool WritePayloadToConsole { get; set; }

    public bool CaptureResponseBody { get; set; }

    public int MaxResponseBodySizeInMb { get; set; }

}