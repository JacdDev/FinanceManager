using FluentValidation;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
            RuleFor(v => v.OwnerId).NotEmpty();
        }
    }
}
