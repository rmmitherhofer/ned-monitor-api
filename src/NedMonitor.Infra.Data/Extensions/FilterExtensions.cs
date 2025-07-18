using NedMonitor.Domain.Entities;
using NedMonitor.Domain.Filters;

namespace NedMonitor.Infra.Data.Extensions;

public static class FilterExtensions
{
    public static IQueryable<ApplicationLog> Filter(this IQueryable<ApplicationLog> query, LogFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.CorrelationId))
            query = query.Where(l => l.CorrelationId.Equals(filter.CorrelationId));

        if (filter.StartDate.HasValue)
            query = query.Where(c => c.RegistrationDate >= filter.StartDate.Value);

        if (filter.EndDate.HasValue)
            query = query.Where(c => c.RegistrationDate <= filter.EndDate.Value);

        return query;
    }
}