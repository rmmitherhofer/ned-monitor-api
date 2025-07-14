using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Environment
{
    public string MachineName { get; private set; }
    public string EnvironmentName { get; private set; }
    public string ApplicationVersion { get; private set; }
    public int ThreadId { get; private set; }

    private Environment() { }

    public static EnvironmentInfoBuilder Create(string machineName, string environmentName)
        => new(machineName, environmentName);

    public class EnvironmentInfoBuilder
    {
        private readonly Environment _environment;

        public EnvironmentInfoBuilder(string machineName, string environmentName)
        {
            if (string.IsNullOrWhiteSpace(machineName))
                throw new DomainException("MachineName is required.");
            if (string.IsNullOrWhiteSpace(environmentName))
                throw new DomainException("EnvironmentName is required.");

            _environment = new Environment
            {
                MachineName = machineName,
                EnvironmentName = environmentName,
                ApplicationVersion = "unknown",
                ThreadId = -1
            };
        }

        public EnvironmentInfoBuilder WithApplicationVersion(string applicationVersion)
        {
            _environment.ApplicationVersion = applicationVersion ?? "unknown";
            return this;
        }

        public EnvironmentInfoBuilder WithThreadId(int threadId)
        {
            if (threadId < 0) throw new DomainException("ThreadId must be non-negative.");

            _environment.ThreadId = threadId;
            return this;
        }

        public Environment Build() => _environment;
    }

    public override string ToString() =>
        $"{MachineName} - {EnvironmentName} - Version: {ApplicationVersion} - ThreadId: {ThreadId}";
}
