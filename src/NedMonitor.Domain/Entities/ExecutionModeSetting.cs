namespace NedMonitor.Domain.Entities;

public class ExecutionModeSetting
{
    public bool EnableNedMonitor { get; private set; }
    public bool EnableMonitorExceptions { get; private set; }
    public bool EnableMonitorNotifications { get; private set; }
    public bool EnableMonitorLogs { get; private set; }
    public bool EnableMonitorHttpRequests { get; private set; }
    public bool EnableMonitorDbQueries { get; private set; }

    public ExecutionModeSetting(bool enableNedMonitor, bool enableMonitorExceptions, bool enableMonitorNotifications, bool enableMonitorLogs, bool enableMonitorHttpRequests, bool enableMonitorDbQueries)
    {
        EnableNedMonitor = enableNedMonitor;
        EnableMonitorExceptions = enableMonitorExceptions;
        EnableMonitorNotifications = enableMonitorNotifications;
        EnableMonitorLogs = enableMonitorLogs;
        EnableMonitorHttpRequests = enableMonitorHttpRequests;
        EnableMonitorDbQueries = enableMonitorDbQueries;
    }
}