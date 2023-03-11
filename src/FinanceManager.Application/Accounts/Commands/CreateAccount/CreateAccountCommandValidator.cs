using FluentValidation;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
