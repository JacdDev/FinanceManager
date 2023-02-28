using FinanceManager.Application.Authentication.Commands.ChangePassword;
using FluentValidation;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
