using FluentValidation;

namespace FinanceManager.Application.Movements.Commands.UpdateMovement
{
    public class UpdateMovementCommandValidator : AbstractValidator<UpdateMovementCommand>
    {
        public UpdateMovementCommandValidator()
        {
            RuleFor(v => v.Concept).NotEmpty().WithMessage("Concept is required");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.MovementId).NotEmpty().WithMessage("Movement ID is required");
            RuleFor(v => v.Amount).GreaterThan(0).WithMessage("Amount must be grater than 0");
            RuleFor(v => v.Tags).NotNull().WithMessage("Tags are required");
        }
    }
}
