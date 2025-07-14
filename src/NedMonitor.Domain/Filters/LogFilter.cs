using Zypher.Persistence.Abstractions.Data.Filters;

namespace NedMonitor.Domain.Filters;

public class LogFilter : Filter
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
