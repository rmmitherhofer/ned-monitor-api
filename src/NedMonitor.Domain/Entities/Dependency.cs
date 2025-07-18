using System.Text.Json.Serialization;
using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Dependency
{
    public string Type { get; private set; }
    public string Target { get; private set; }
    public bool Success { get; private set; }
    public int DurationMs { get; private set; }

    protected Dependency() { }

    public Dependency(string type, string target, bool success, int durationMs)
    {
        if (string.IsNullOrWhiteSpace(type)) throw new DomainException("Type is required.");
        if (string.IsNullOrWhiteSpace(target)) throw new DomainException("Target is required.");
        if (durationMs < 0) throw new DomainException("Duration must be non-negative.");

        Type = type;
        Target = target;
        Success = success;
        DurationMs = durationMs;
    }
    public override string ToString() =>
        $"{Type} => {Target} (Success: {Success}, Duration: {DurationMs}ms)";
}
