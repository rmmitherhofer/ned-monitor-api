using Api.Core.Data;
using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Filters;

namespace NedMonitor.Domain.Interfaces;

public interface ILogRepository : IRepository<ApplicationLog>
{
    Task<(IEnumerable<ApplicationLog> logs, int pageCount, int totalRecords)> GetPaginated(LogFilter filter);
}
