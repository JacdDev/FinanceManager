using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryValidator : AbstractValidator<GetAccountsQuery>
    {
        public GetAccountsQueryValidator()
        {
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
        }
    }
}
