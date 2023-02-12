using FluentValidation;

namespace FinanceManager.Application.Settings.Commands.ChangeEmail
{
    public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
    {
        public ChangeEmailCommandValidator()
        {
            RuleFor(v => v.NewEmail).NotEmpty().WithMessage("Email is required");
            RuleFor(v => v.NewEmail).EmailAddress().WithMessage("Invalid email format");
        }
    }
}
