using FluentValidation;

namespace FinanceManager.Application.Settings.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(v => v.NewPassword).NotEmpty().WithMessage("Password is required");
            RuleFor(v => v.NewPassword).MinimumLength(8).WithMessage("Password length must be equal or greater than 8");
            RuleFor(v => v.NewPassword).Matches("[A-Z]").WithMessage("Password must contain an uppercase letter");
            RuleFor(v => v.NewPassword).Matches("[a-z]").WithMessage("Password must contain an lowercase letter");
            RuleFor(v => v.NewPassword).Matches("[0-9]").WithMessage("Password must contain a number");
            RuleFor(v => v.NewPassword).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain a special character");
        }
    }
}
