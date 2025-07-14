using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Filters;
using Zypher.Persistence.Abstractions.Data;

namespace NedMonitor.Domain.Interfaces;

public interface ILogRepository : IRepository<ApplicationLog>
{
    Task<(IEnumerable<ApplicationLog> logs, int pageCount, int totalRecords)> GetPaginated(LogFilter filter);
}
