using Common.Exceptions;
using NedMonitor.Domain.Enums;

namespace NedMonitor.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ProjectType Type { get; private set; }
    public SnapTraceExecutionMode ExecutionMode { get; private set; }
    public int MaxResponseBodySizeInMb { get; private set; }
    public bool CaptureResponseBody { get; private set; }
    public bool WritePayloadToConsole { get; private set; }

    private Project() { }

    public static ProjectInfoBuilder Create(Guid id, string name, ProjectType type) => new(id, name, type);

    public class ProjectInfoBuilder
    {
        private readonly Project _project;

        public ProjectInfoBuilder(Guid id, string name, ProjectType type)
        {
            if (id == Guid.Empty) throw new DomainException("Id must be a valid GUID.");
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name is required.");

            _project = new Project
            {
                Id = id,
                Name = name,
                Type = type,
                ExecutionMode = SnapTraceExecutionMode.Disabled,
                MaxResponseBodySizeInMb = 1,
                CaptureResponseBody = false,
                WritePayloadToConsole = false
            };
        }

        public ProjectInfoBuilder WithExecutionMode(SnapTraceExecutionMode executionMode)
        {
            _project.ExecutionMode = executionMode;
            return this;
        }

        public ProjectInfoBuilder WithMaxResponseBodySize(int maxSizeMb)
        {
            if (maxSizeMb < 0) throw new DomainException("MaxResponseBodySizeInMb must be >= 0.");
            _project.MaxResponseBodySizeInMb = maxSizeMb;
            return this;
        }

        public ProjectInfoBuilder CaptureResponseBodyEnabled(bool enabled)
        {
            _project.CaptureResponseBody = enabled;
            return this;
        }

        public ProjectInfoBuilder WritePayloadToConsoleEnabled(bool enabled)
        {
            _project.WritePayloadToConsole = enabled;
            return this;
        }

        public Project Build() => _project;
    }

    public override string ToString() => $"{Name} ({Id}) - Type: {Type}, Mode: {ExecutionMode}";
}
