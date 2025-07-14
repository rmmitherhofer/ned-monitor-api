namespace NedMonitor.Domain.Entities;

public class HttpLoggingSetting
{
    public bool WritePayloadToConsole { get; private set; }

    public bool CaptureResponseBody { get; private set; }

    public int MaxResponseBodySizeInMb { get; private set; }

    public HttpLoggingSetting(bool writePayloadToConsole, bool captureResponseBody, int maxResponseBodySizeInMb)
    {
        WritePayloadToConsole = writePayloadToConsole;
        CaptureResponseBody = captureResponseBody;
        MaxResponseBodySizeInMb = maxResponseBodySizeInMb;
    }
}