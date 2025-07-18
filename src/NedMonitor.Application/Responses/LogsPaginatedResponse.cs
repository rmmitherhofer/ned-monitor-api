using Zypher.Responses;

namespace NedMonitor.Application.Responses;

public class LogsPaginatedResponse : PaginatedResponse
{
    public IEnumerable<ApplicationLogResponse> Logs { get; set; }

    public LogsPaginatedResponse(int totalRecords,
        int pageNumber,
        int pageCount,
        IEnumerable<ApplicationLogResponse> logs) :
        base(totalRecords, pageNumber, pageCount, logs.Count()) => Logs = logs;

}
