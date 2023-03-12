using FluentValidation;

namespace FinanceManager.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
            RuleFor(v => v.OwnerId).NotEmpty();
            RuleFor(v => v.Description).NotEmpty();
            RuleFor(v => v.AccountId).NotEmpty();
        }
    }
}
