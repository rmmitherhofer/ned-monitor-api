using FluentValidation.Results;
using MediatR;

namespace NedMonitor.Application.Core;

public abstract class Command : Message, IRequest<ValidationResult>
{
    public DateTime TimeStamp { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command() => TimeStamp = DateTime.UtcNow;

    public virtual bool IsValid() => throw new NotImplementedException();
}
