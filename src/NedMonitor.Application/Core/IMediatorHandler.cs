using FluentValidation.Results;

namespace NedMonitor.Application.Core;

public interface IMediatorHandler
{
    Task Publish<T>(T eventItem) where T : Event;
    Task<ValidationResult> Send<T>(T command) where T : Command;
}
