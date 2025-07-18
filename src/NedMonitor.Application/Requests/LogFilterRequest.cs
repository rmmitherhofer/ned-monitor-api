using Zypher.Requests;

namespace NedMonitor.Application.Requests;

public class LogFilterRequest : FilterRequest
{
    public string CorrelationId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}