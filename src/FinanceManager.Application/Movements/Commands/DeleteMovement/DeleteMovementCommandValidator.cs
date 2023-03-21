using FluentValidation;

namespace FinanceManager.Application.Movements.Commands.DeleteMovement
{
    public class DeleteMovementCommandValidator : AbstractValidator<DeleteMovementCommand>
    {
        public DeleteMovementCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().WithMessage("User ID is required");
            RuleFor(v => v.MovementId).NotEmpty().WithMessage("Movement ID is required");
        }
    }
}
