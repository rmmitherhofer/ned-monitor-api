namespace NedMonitor.Application.Responses;

public class ExecutionModeSettingResponse
{
    public bool EnableNedMonitor { get; set; }
    public bool EnableMonitorExceptions { get; set; }
    public bool EnableMonitorNotifications { get; set; }
    public bool EnableMonitorLogs { get; set; }
    public bool EnableMonitorHttpRequests { get; set; }
    public bool EnableMonitorDbQueries { get; set; }

}