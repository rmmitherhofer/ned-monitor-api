using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Diagnostic
{
    public double MemoryUsageMb { get; private set; }
    public int DbQueryCount { get; private set; }
    public bool CacheHit { get; private set; }
    public IReadOnlyList<Dependency> Dependencies { get; private set; }
    private Diagnostic() => Dependencies = [];

    public static DiagnosticInfoBuilder Create() => new();

    public class DiagnosticInfoBuilder
    {
        private readonly Diagnostic _diagnostic = new();

        public DiagnosticInfoBuilder WithMemoryUsage(double memoryUsageMb)
        {
            if (memoryUsageMb < 0) throw new DomainException("Memory usage must be non-negative.");

            _diagnostic.MemoryUsageMb = memoryUsageMb;
            return this;
        }

        public DiagnosticInfoBuilder WithDbQueryCount(int dbQueryCount)
        {
            _diagnostic.DbQueryCount = dbQueryCount;
            return this;
        }

        public DiagnosticInfoBuilder WithCacheHit(bool cacheHit)
        {
            _diagnostic.CacheHit = cacheHit;
            return this;
        }

        public DiagnosticInfoBuilder WithDependencies(IEnumerable<Dependency>? dependencies)
        {
            _diagnostic.Dependencies = dependencies != null ? new List<Dependency>(dependencies) : [];
            return this;
        }

        public Diagnostic Build() => _diagnostic;
    }

    public override string ToString() =>
        $"Memory: {MemoryUsageMb} MB, DB Queries: {DbQueryCount}, CacheHit: {CacheHit}, Dependencies: {Dependencies.Count}";
}
