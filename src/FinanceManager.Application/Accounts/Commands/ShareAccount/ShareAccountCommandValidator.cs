using FinanceManager.Application.Accounts.Commands.UpdateAccount;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
