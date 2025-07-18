using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Filters;
using NedMonitor.Domain.Interfaces;
using NedMonitor.Infra.Data.Extensions;
using Zypher.Logs.Extensions;
using Zypher.Persistence.Abstractions.Data;
using Zypher.Api.Data.Extensions;

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
            .Include(l => l.HttpClientLogs)
            .Include(l => l.DbQueryEntries)
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

        var teste =  await _context.Logs
            .Include(l => l.Notifications)
            .Include(l => l.LogEntries)
            .Include(l => l.Exceptions)
            .Include(l => l.HttpClientLogs)
            .Include(l => l.DbQueryEntries)
            .AsNoTracking()
            .ToListAsync();

        return teste;
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