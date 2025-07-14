using FluentValidation.Results;
using Zypher.Persistence.Abstractions.Data;

namespace NedMonitor.Application.Core;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;
    protected CommandHandler() => ValidationResult = new ValidationResult();

    protected void AddError(string message) => ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));

    protected async Task<ValidationResult> Commit(IUnitOfWork uow)
    {
        var (success, operationType) = await uow.Commit();

        if (!success)
            AddError($"Failed to commit changes. Operation type: {operationType}");

        return ValidationResult;
    }
}