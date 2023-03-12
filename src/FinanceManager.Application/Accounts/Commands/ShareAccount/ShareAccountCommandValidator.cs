using FluentValidation;

namespace FinanceManager.Application.Accounts.Commands.ShareAccount
{
    public class ShareAccountCommandValidator : AbstractValidator<ShareAccountCommand>
    {
        public ShareAccountCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(v => v.Email).EmailAddress().WithMessage("Invalid email format");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.AccountId).NotEmpty().WithMessage("Account ID is required");
        }
    }
}
