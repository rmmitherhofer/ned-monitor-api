using NedMonitor.Application.Requests;
using NedMonitor.Application.Responses;

namespace NedMonitor.Application.Queries;

public interface ILogQuery
{
    Task<LogsPaginatedResponse> Get(LogFilterRequest request);
}
