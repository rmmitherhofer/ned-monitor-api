namespace NedMonitor.Domain.Entities;

public class ExceptionsSetting
{
    public List<string>? Expected { get; private set; }
    public ExceptionsSetting(List<string>? expected)
    {
        Expected = expected;
    }
}