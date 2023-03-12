using FluentValidation;

namespace FinanceManager.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().WithMessage("User ID is required");
            RuleFor(v => v.AccountId).NotEmpty().WithMessage("Account ID is required");
        }
    }
}
