using Microsoft.Extensions.Logging;
using NedMonitor.Domain.Enums;
using Zypher.Domain.Exceptions;

namespace NedMonitor.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; }
    public ProjectType Type { get; private set; }
    public string Name { get; private set; }
    public ExecutionModeSetting ExecutionMode { get; private set; }
    public HttpLoggingSetting? HttpLogging { get; private set; }
    public SensitiveDataMaskerSetting? SensitiveDataMasking { get; private set; }
    public ExceptionsSetting? Exceptions { get; private set; }
    public DataInterceptorsSetting? DataInterceptors { get; private set; }
    public LogLevel MinimumLogLevel { get; private set; }
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
                Type = type
            };
        }

        public ProjectInfoBuilder WithExecutionMode(ExecutionModeSetting executionMode)
        {
            _project.ExecutionMode = executionMode ?? throw new ArgumentNullException(nameof(executionMode));
            return this;
        }

        public ProjectInfoBuilder WithHttpLogging(HttpLoggingSetting httpLogging)
        {
            _project.HttpLogging = httpLogging;
            return this;
        }

        public ProjectInfoBuilder WithSensitiveDataMasking(SensitiveDataMaskerSetting masking)
        {
            _project.SensitiveDataMasking = masking;
            return this;
        }

        public ProjectInfoBuilder WithExceptions(ExceptionsSetting exceptions)
        {
            _project.Exceptions = exceptions;
            return this;
        }

        public ProjectInfoBuilder WithDataInterceptors(DataInterceptorsSetting interceptors)
        {
            _project.DataInterceptors = interceptors;
            return this;
        }

        public ProjectInfoBuilder WithMinimumLogLevel(LogLevel level)
        {
            _project.MinimumLogLevel = level;
            return this;
        }

        public Project Build() => _project;
    }

    public override string ToString() => $"{Name} ({Id}) - Type: {Type}, Mode: {ExecutionMode}";
}
