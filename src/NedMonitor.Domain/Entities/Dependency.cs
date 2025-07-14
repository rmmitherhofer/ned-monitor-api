using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Dependency
{
    public string Type { get; private set; }
    public string Target { get; private set; }
    public bool Success { get; private set; }
    public int DurationMs { get; private set; }

    private Dependency() { }

    public static DependencyInfoBuilder Create(string type, string target) => new(type, target);

    public class DependencyInfoBuilder
    {
        private readonly Dependency _dependency = new();

        public DependencyInfoBuilder(string type, string target)
        {
            if (string.IsNullOrWhiteSpace(type)) throw new DomainException("Type is required.");
            if (string.IsNullOrWhiteSpace(target)) throw new DomainException("Target is required.");

            _dependency.Type = type;
            _dependency.Target = target;
        }

        public DependencyInfoBuilder IsSuccess(bool success)
        {
            _dependency.Success = success;
            return this;
        }

        public DependencyInfoBuilder WithDuration(int durationMs)
        {
            if (durationMs < 0) throw new DomainException("Duration must be non-negative.");
            _dependency.DurationMs = durationMs;
            return this;
        }

        public Dependency Build() => _dependency;
    }

    public override string ToString() =>
        $"{Type} => {Target} (Success: {Success}, Duration: {DurationMs}ms)";
}
