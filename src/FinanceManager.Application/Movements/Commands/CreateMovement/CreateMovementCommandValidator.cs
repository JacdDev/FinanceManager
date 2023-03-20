using FluentValidation;

namespace FinanceManager.Application.Movements.Commands.CreateMovement
{
    public class CreateMovementCommandValidator : AbstractValidator<CreateMovementCommand>
    {
        public CreateMovementCommandValidator()
        {
            RuleFor(v => v.Concept).NotEmpty().WithMessage("Concept is required");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.AccountId).NotEmpty().WithMessage("Account ID is required");
            RuleFor(v => v.Amount).GreaterThan(0).WithMessage("Ammount must be grater than 0");
            RuleFor(v => v.Tags).NotNull().WithMessage("Tags are required");
        }
    }
}
