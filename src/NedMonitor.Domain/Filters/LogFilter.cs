using Zypher.Persistence.Abstractions.Data.Filters;

namespace NedMonitor.Domain.Filters;

public class LogFilter : Filter
{
    public string CorrelationId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
