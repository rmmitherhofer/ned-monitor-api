using AutoMapper;
using Microsoft.Extensions.Logging;
using NedMonitor.Application.Requests;
using NedMonitor.Application.Responses;
using NedMonitor.Domain.Filters;
using NedMonitor.Domain.Interfaces;

namespace NedMonitor.Application.Queries;

public class LogQuery : ILogQuery
{
    private readonly ILogger<LogQuery> _logger;
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;

    public LogQuery(ILogger<LogQuery> logger, ILogRepository logRepository, IMapper mapper)
    {
        _logger = logger;
        _logRepository = logRepository;
        _mapper = mapper;
    }

    public async Task<LogsPaginatedResponse> Get(LogFilterRequest request)
    {
        var (logs, pageCount, totalRecords) = await _logRepository.GetPaginated(_mapper.Map<LogFilter>(request));

        return new(totalRecords, request.PageNumber, pageCount, _mapper.Map<IEnumerable<ApplicationLogResponse>>(logs));
    }
}