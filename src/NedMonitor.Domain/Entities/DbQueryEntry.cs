using NedMonitor.Domain.Entities;
using Zypher.Domain.Core.DomainObjects;
using Zypher.Domain.Exceptions;

public class DbQueryEntry : Entity
{
    public string Provider { get; private set; }
    public string Sql { get; private set; } = string.Empty;
    public string Parameters { get; private set; } = string.Empty;
    public DateTime ExecutedAtUtc { get; private set; }
    public double DurationMs { get; private set; }
    public bool Success { get; private set; }
    public string? ExceptionMessage { get; private set; }
    public IDictionary<string, string>? DbContext { get; private set; }
    public string ORM { get; private set; }

    public ApplicationLog ApplicationLog { get; protected set; }
    public Guid LogId { get; private set; }
    public string CorrelationId { get; private set; }

    public static DbQueryEntryBuilder Create(string provider, DateTime executedAtUtc, double durationMs, bool success, string orm) =>
        new(provider, executedAtUtc, durationMs, success, orm);

    internal void SetParent(ApplicationLog log)
    {
        LogId = log.Id;
        CorrelationId = log.CorrelationId;
    }

    public class DbQueryEntryBuilder
    {
        private readonly DbQueryEntry _entry;

        public DbQueryEntryBuilder(string provider, DateTime executedAtUtc, double durationMs, bool success, string orm)
        {
            if (executedAtUtc == DateTime.MinValue) throw new DomainException("ExecutedAtUtc must be a valid UTC timestamp.");
            if (string.IsNullOrWhiteSpace(orm)) throw new DomainException("ORM is required.");
            if (string.IsNullOrWhiteSpace(provider)) throw new DomainException("Provider is required.");

            _entry = new DbQueryEntry
            {
                Provider = provider,
                ExecutedAtUtc = executedAtUtc,
                Success = success,
                ORM = orm,
                DurationMs = durationMs
            };
        }

        public DbQueryEntryBuilder WithSql(string? sql)
        {
            _entry.Sql = sql ?? string.Empty;
            return this;
        }

        public DbQueryEntryBuilder WithParameters(string? parameters)
        {
            _entry.Parameters = parameters ?? string.Empty;
            return this;
        }

        public DbQueryEntryBuilder WithException(string? message)
        {
            _entry.ExceptionMessage = message;
            return this;
        }

        public DbQueryEntryBuilder WithDbContext(IDictionary<string, string>? dbContext)
        {
            _entry.DbContext = dbContext;
            return this;
        }

        public DbQueryEntry Build() => _entry;
    }

    public override string ToString()
    {
        return $"[{ORM}] {ExecutedAtUtc:u} | {Provider} | Success: {Success} | Duration: {DurationMs}ms";
    }
}
