using Api.Core.Data;
using Api.Data.Extensions;
using Common.Logs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Filters;
using NedMonitor.Domain.Interfaces;
using NedMonitor.Infra.Data.Extensions;

namespace NedMonitor.Infra.Data.Repositories;

public class LogRepository : ILogRepository
{
    private readonly NedMonitorContext _context;
    private readonly ILogger<LogRepository> _logger;
    public LogRepository(NedMonitorContext context, ILogger<LogRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<(IEnumerable<ApplicationLog> logs, int pageCount, int totalRecords)> GetPaginated(LogFilter filter)
    {
        _logger.LogInfo("Retrieving paginated logs with filter: {@Filter}", filter);

        var query = _context.Logs.Filter(filter);

        var totalRecords = await query.CountAsync();

        int pageCount = filter.GetPageCount(totalRecords);

        var logs = await query
            .Include(l => l.Notifications)
            .Include(l => l.LogEntries)
            .Include(l => l.Exceptions)
            .OrderBy(filter.OrderBy)
            .Page(filter.PageNumber, filter.PageSize)
            .AsNoTracking()
            .ToListAsync();

        return (logs, pageCount, totalRecords);
    }

    public void Add(ApplicationLog entity)
    {
        _logger.LogInfo("Adding log with ID: {LogId}", entity.Id);

        _context.Logs.Add(entity);
    }

    public void Dispose() => _context.Dispose();

    public async Task<IEnumerable<ApplicationLog>> GetAll()
    {
        _logger.LogInfo("Retrieving all logs");

        return await _context.Logs
            .Include(l => l.Notifications)
            .Include(l => l.LogEntries)
            .Include(l => l.Exceptions)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ApplicationLog?> GetById(Guid id)
    {
        _logger.LogInfo("Retrieving log by Id: {Id}", id);

        return await _context.Logs.Where(l => l.Id == id)
            .Include(l => l.Notifications)
            .Include(l => l.LogEntries)
            .Include(l => l.Exceptions)
            .FirstOrDefaultAsync();
    }

    public void Remove(ApplicationLog entity)
    {
        _logger.LogInfo("Removing log with ID: {LogId}", entity.Id);

        _context.Logs.Remove(entity);
    }

    public void Update(ApplicationLog entity)
    {
        _logger.LogInfo("Updating log with ID: {LogId}", entity.Id);

        _context.Logs.Update(entity);
    }
}